# CineClub - Film İnceleme Sistemi

CineClub, kullanıcıların filmleri inceleyip değerlendirebildiği bir ASP.NET Core MVC web uygulamasıdır. Kullanıcı yönetimi, rol bazlı yetkilendirme ve RESTful API ile veri erişimi sağlar.  

## Uygulanan Özellikler

### Benzersiz Yorum Kısıtlaması
Sistem, standart kullanıcıların her film için yalnızca bir kez yorum yapmasına izin verir.  
- `ReviewController/Create` aksiyonunda, kullanıcının aynı filme daha önce yorum yapıp yapmadığı kontrol edilir.  
- Aynı filme tekrar yorum yapılmak istenirse işlem engellenir ve kullanıcıya bilgilendirici bir mesaj gösterilir.  

### Düzenleme Bilgisi ve Zaman Takibi
Yorumlar üzerinde yapılan güncellemeler şeffaf şekilde gösterilir.  
- `Review` modeli içinde `CreatedAtUtc` ve `UpdatedAtUtc` alanları bulunur.  
- Yorum güncellendiğinde, düzenlenme tarihi ve saati arayüzde gösterilir.  

### En Yüksek Puanlı Filmler API
Filmler, kullanıcı değerlendirmelerine göre sıralanarak API üzerinden sunulur.  

### Film Yorumları API
Belirli bir filme ait yorumlar (metin, puan, tarih, kullanıcı) API ile alınabilir.  

## Teknoloji
- **Framework:** ASP.NET Core 9.0  
- **Mimari:** MVC  
- **Kimlik Yönetimi:** Identity (Admin, User)  
- **Veritabanı:** Entity Framework Core  

## Kurulum
1. .NET 9 SDK yüklü olmalı  
2. `appsettings.json` veritabanı ayarları kontrol edilmeli  
3. Terminalde çalıştır:

```bash
dotnet run
