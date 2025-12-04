🌌 Kuantum Kaos Yönetimi (Omega Sektörü)
Bu proje, Omega Sektörü Kuantum Veri Ambarı'nın yönetimini simüle eden bir C# Konsol Uygulamasıdır. Proje, Nesne Yönelimli Programlama (OOP) prensiplerini kullanarak kararsız ve tehlikeli maddelerin (Veri Paketi, Karanlık Madde, Anti Madde) yönetimini, analizini ve acil durum soğutma işlemlerini gerçekleştirir.

🎯 Proje Amacı
Evrenin en kararsız maddelerini dijital ortamda saklamak, analiz etmek ve stabilite seviyeleri kritik düzeye düşmeden (0 ve altı) gün sonunu getirmektir. Eğer bir nesnenin stabilitesi tükenirse Kuantum Çöküşü (Quantum Collapse) gerçekleşir ve simülasyon sonlanır.

🛠️ Teknik Özellikler ve Mimari
Bu proje, aşağıdaki OOP prensiplerine tam uyumluluk gösterecek şekilde tasarlanmıştır:


Soyutlama (Abstraction): Tüm nesneler, ortak özelliklerin (ID, Stabilite, Tehlike Seviyesi) tanımlandığı KuantumNesnesi soyut sınıfından türetilmiştir.

Kapsülleme (Encapsulation): Stabilite değeri 0-100 aralığında tutulur. Kontrolsüz veri girişi engellenmiş ve stabilite takibi güvenli hale getirilmiştir.

Arayüz Ayrımı (Interface Segregation): Her nesne soğutulamaz. Sadece tehlikeli olanlar (Karanlık Madde ve Anti Madde) IKritik arayüzünü uygulayarak AcilDurumSogutmasi yeteneğine sahip olmuştur.


Polimorfizm (Polymorphism): AnalizEt() metodu her alt sınıfta farklı davranışlar sergiler (Örn: Veri paketi az hasar alırken, Anti Madde büyük hasar alır).


Özel Hata Yönetimi (Custom Exception): Stabilite kaybı durumunda standart hatalar yerine KuantumCokusuException fırlatılarak oyunun akışı kontrol altına alınmıştır.

📦 Sınıf Hiyerarşisi
KuantumNesnesi (Abstract Class)

VeriPaketi: Güvenli nesne. Analiz edildiğinde az stabilite kaybeder.

KaranlikMadde: Tehlikeli nesne (IKritik). Soğutulabilir.

AntiMadde: Çok tehlikeli nesne (IKritik). Analiz edildiğinde yüksek stabilite kaybeder.

🚀 Kurulum ve Çalıştırma
Bu repoyu klonlayın veya indirin.

Projeyi Visual Studio veya VS Code ile açın.

Terminal veya konsol ekranında projeyi derleyin ve çalıştırın.

Bash

dotnet run
🎮 Oynanış (Kontroller)
Program çalıştığında aşağıdaki menü üzerinden interaktif yönetim sağlanır:

Yeni Nesne Ekle: Depoya Veri Paketi, Karanlık Madde veya Anti Madde ekler.

Envanteri Listele: Depodaki tüm nesnelerin durumunu (ID, Stabilite, Tehlike) raporlar.

Nesneyi Analiz Et: Girilen ID'ye sahip nesneyi analiz eder (Stabilite düşer).

Acil Durum Soğutması: Sadece Kritik (IKritik) nesneleri soğutur (+50 Stabilite).

Çıkış: Simülasyonu sonlandırır.

⚠️ DİKKAT: Stabilite %0 veya altına düşerse sistem çöker!

📝 Proje Raporu (Özet)
Bu projede, kaotik bir veri ambarını yönetilebilir kılmak adına OOP prensipleri bir iskelet olarak kullanılmıştır. KuantumNesnesi ile kod tekrarı önlenmiş, IKritik arayüzü ile yetenekler ayrıştırılmıştır. Sistemin en kritik parçası olan hata yönetimi, try-catch blokları ve özel KuantumCokusuException sınıfı ile sağlanmıştır. Bu sayede, kullanıcı hataları veya oyun içi "patlama" durumları kontrollü bir şekilde yönetilerek simülasyonun tutarlılığı korunmuştur.

Geliştirici: [EMRE BULCA] Ders: Nesne Yönelimli Programlama
