using System;
using System.Collections.Generic;

namespace KuantumC
{
   
    // 1. ÖZEL HATA YÖNETİMİ (CUSTOM EXCEPTION)
    // Ödev Gereği: Sıradan hatalar yerine sistemin çöktüğünü belirten özel bir hata sınıfı.
    // Bir nesne patladığında bu hatayı fırlatacağız.
    public class KuantumCokusuException : Exception
    {
        public KuantumCokusuException(string message) : base(message) { }
    }

    // 2. ARAYÜZ (INTERFACE SEGREGATION)
    // Her nesne soğutulamaz. Sadece tehlikeli olanlar (Karanlık Madde ve Anti Madde)
    // bu yeteneğe (metoda) sahip olmalı.
    public interface IKritik
    {
        void AcilDurumSogutmasi(); // Bu metodu uygulayan sınıf, içini doldurmak zorundadır.
    }

    // 3. ANA SOYUT SINIF (ABSTRACT CLASS)
    // Tüm maddelerin ortak atası. Veri Paketi, Karanlık Madde vb. buradan türeyecek.
    public abstract class KuantumNesnesi
    {
        public string ID { get; set; } // Nesnenin kimliği

        // Kapsülleme (Encapsulation) için gizli değişken
        private double _stabilite;

        // Dış dünyadan erişilen özellik (Property)
        public double Stabilite
        {
            get { return _stabilite; }
            set
            {
                _stabilite = value;

                // Ödev Gereği: Stabilite 100'den büyük olamaz.
                if (_stabilite > 100) _stabilite = 100;

                // Ödev Gereği: 0 veya altına düşerse OYUN BİTER (Exception fırlatılır).
                // Bu kısım projenin sigortasıdır.
                if (_stabilite <= 0)
                {
                    _stabilite = 0;
                    // Hata fırlatılınca kodun akışı durur ve 'catch' bloğuna gider.
                    throw new KuantumCokusuException($"{ID} isimli nesne kararsızlaştı ve PATLADI!");
                }
            }
        }

        public int TehlikeSeviyesi { get; set; } // 1-10 arası tehlike puanı

        // Soyut Metot: Alt sınıflar bu metodu (AnalizEt) kendine göre EZMEK (Override) zorundadır.
        public abstract void AnalizEt();

        // Ortak Metot: Her nesne durumunu bu şekilde raporlar.
        public string DurumBilgisi()
        {
            return $"ID: {ID} | Stabilite: %{Stabilite} | Tehlike: {TehlikeSeviyesi}";
        }
    }

    // 4. NESNE ÇEŞİTLERİ (INHERITANCE & POLYMORPHISM)

    // A. Veri Paketi (Tehlikesiz Nesne)
    // IKritik değildir, yani soğutulamaz.
    public class VeriPaketi : KuantumNesnesi
    {
        // Polimorfizm: Analiz edilince az hasar görür.
        public override void AnalizEt()
        {
            Stabilite -= 5; // Sadece 5 birim düşer.
            Console.WriteLine("Veri içeriği okundu.");
        }
    }

    // B. Karanlık Madde (Tehlikeli Nesne)
    // IKritik arayüzünü uygular (Implemente eder).
    public class KaranlikMadde : KuantumNesnesi, IKritik
    {
        public override void AnalizEt()
        {
            Stabilite -= 15; // 15 birim düşer, orta tehlike.
        }

        // Interface'den gelen zorunlu metot
        public void AcilDurumSogutmasi()
        {
            Stabilite += 50; // Soğutunca stabilite artar.
            Console.WriteLine($"{ID} soğutuldu. Yeni Stabilite: {Stabilite}");
        }
    }

    // C. Anti Madde (Çok Tehlikeli Nesne)
    // IKritik arayüzünü uygular.
    public class AntiMadde : KuantumNesnesi, IKritik
    {
        public override void AnalizEt()
        {
            Stabilite -= 25; // Çok hızlı düşer, yüksek tehlike.
            Console.WriteLine("Evrenin dokusu titriyor..."); // Uyarı mesajı
        }

        public void AcilDurumSogutmasi()
        {
            Stabilite += 50;
            Console.WriteLine($"{ID} için kritik soğutma uygulandı.");
        }
    }

    // 5. OYUN DÖNGÜSÜ (MAIN PROGRAM)
    class Program
    {
        static void Main(string[] args)
        {
            // Envanter: Tüm nesneleri (türü ne olursa olsun) burada tutuyoruz.
            // Generic List kullanımı [cite: 55]
            List<KuantumNesnesi> envanter = new List<KuantumNesnesi>();

            Console.WriteLine("SİSTEM BAŞLATILIYOR...");

            // Sonsuz Döngü (Main Loop): Kullanıcı çıkış diyene kadar veya sistem çökene kadar döner.
            while (true)
            {
                Console.WriteLine("\n=== OMEGA SEKTÖRÜ KUANTUM AMBARI ===");
                Console.WriteLine("1. Yeni Nesne Ekle");
                Console.WriteLine("2. Tüm Envanteri Listele");
                Console.WriteLine("3. Nesneyi Analiz Et");
                Console.WriteLine("4. Acil Durum Soğutması Yap");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                // Hata Yakalama (Exception Handling)
                // Eğer bir nesne patlarsa (Exception fırlatırsa) buradaki 'catch' bloğu devreye girer.
                try
                {
                    switch (secim)
                    {
                        case "1":
                            EklemeMenusu(envanter);
                            break;
                        case "2":
                            ListelemeMenusu(envanter);
                            break;
                        case "3":
                            AnalizMenusu(envanter);
                            break;
                        case "4":
                            SogutmaMenusu(envanter);
                            break;
                        case "5":
                            Console.WriteLine("Çıkış yapılıyor...");
                            return; // Programdan tamamen çıkar.
                        default:
                            Console.WriteLine("Geçersiz seçim!");
                            break;
                    }
                }
                // GAME OVER BLOĞU
                catch (KuantumCokusuException ex)
                {
                    // Ekranı temizleyip kırmızı renkte çöküş mesajı veriyoruz.
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n************************************************");
                    Console.WriteLine("SİSTEM ÇÖKTÜ! TAHLİYE BAŞLATILIYOR...");
                    Console.WriteLine($"SEBEP: {ex.Message}"); // Hatanın detayını yazdır.
                    Console.WriteLine("************************************************\n");
                    Console.ResetColor();
                    break; // while döngüsünü kırar ve program biter.
                }
                catch (Exception genelHata)
                {
                    // Öngörülemeyen başka bir hata olursa program kapanmasın, bilgi versin.
                    Console.WriteLine("Beklenmedik bir hata: " + genelHata.Message);
                }
            }

            Console.WriteLine("Simülasyon Sonlandı. Çıkmak için bir tuşa bas.");
            Console.ReadKey();
        }

        // --- YARDIMCI METOTLAR (Kodun daha temiz görünmesi için) ---

        static void EklemeMenusu(List<KuantumNesnesi> envanter)
        {
            Console.WriteLine("\n--- Nesne Üretim ---");
            Console.WriteLine("Tip Seç: (1) Veri Paketi, (2) Karanlık Madde, (3) Anti Madde");
            string tip = Console.ReadLine();
            Console.Write("Nesne ID giriniz: ");
            string id = Console.ReadLine();

            // Seçilen tipe göre ilgili sınıftan nesne üretip listeye ekliyoruz.
            if (tip == "1")
                envanter.Add(new VeriPaketi { ID = id, Stabilite = 100, TehlikeSeviyesi = 1 });
            else if (tip == "2")
                envanter.Add(new KaranlikMadde { ID = id, Stabilite = 100, TehlikeSeviyesi = 5 });
            else if (tip == "3")
                envanter.Add(new AntiMadde { ID = id, Stabilite = 100, TehlikeSeviyesi = 10 });
            else
                Console.WriteLine("Geçersiz tip.");

            Console.WriteLine($"{id} envantere eklendi.");
        }

        static void ListelemeMenusu(List<KuantumNesnesi> envanter)
        {
            Console.WriteLine("\n--- Envanter Raporu ---");
            // Polimorfizm Örneği:
            // Listede farklı türler olsa da hepsi 'KuantumNesnesi' olduğu için 
            // hepsinin DurumBilgisi() metodunu aynı döngüde çağırabiliyoruz.
            foreach (var nesne in envanter)
            {
                Console.WriteLine(nesne.DurumBilgisi());
            }
        }

        static void AnalizMenusu(List<KuantumNesnesi> envanter)
        {
            Console.Write("\nAnaliz edilecek ID: ");
            string id = Console.ReadLine();
            // Lambda Expression ile ID arama
            var nesne = envanter.Find(x => x.ID == id);

            if (nesne != null)
            {
                // DİKKAT: Bu metod çalışırken stabilite düşer.
                // Eğer 0'ın altına düşerse hata fırlatır ve 'catch' bloğuna gideriz.
                nesne.AnalizEt();
                Console.WriteLine($"İşlem tamam. {nesne.ID} Stabilite: %{nesne.Stabilite}");
            }
            else
            {
                Console.WriteLine("Nesne bulunamadı!");
            }
        }

        static void SogutmaMenusu(List<KuantumNesnesi> envanter)
        {
            Console.Write("\nSoğutulacak ID: ");
            string id = Console.ReadLine();
            var nesne = envanter.Find(x => x.ID == id);

            // Type Checking (Tür Kontrolü):
            // Nesnenin IKritik olup olmadığını 'is' anahtar kelimesiyle kontrol ediyoruz.
            if (nesne is IKritik kritikNesne)
            {
                kritikNesne.AcilDurumSogutmasi(); // Eğer kritikse soğut.
            }
            else if (nesne != null)
            {
                // Eğer nesne var ama kritik değilse (Örn: Veri Paketi)
                Console.WriteLine("HATA: Bu nesne soğutulamaz! (IKritik değil)");
            }
            else
            {
                Console.WriteLine("Nesne bulunamadı.");
            }
        }
    }
}