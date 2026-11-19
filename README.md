# Planet

Unity ve AR Foundation kullanılarak geliştirilen artırılmış gerçeklik güneş
sistemi uygulaması. Kullanıcı, ana menü üzerinden bir gezegen veya güneş
sistemi sahnesi seçebilir; seçilen 3B içerik telefon kamerası görüntüsünün
önünde AR ortamına yerleştirilir.

## Özellikler

- Dünya, Mars, Jüpiter, Merkür, Neptün, Satürn, Uranüs ve Venüs için ayrı
  sahneler
- Tüm gezegenleri birlikte gösteren `Solar System` sahnesi
- AR oturumu ve kamera arka planı ile gerçek ortam üzerine yerleştirme
- Gezegenlerin kendi ekseninde dönmesi ve güneş etrafında yörüngede hareket
  etmesi
- AR oturumunu yenileyerek gezegeni kameranın önünde yeniden konumlandırma

## Gereksinimler

- Unity **6000.6.7f1**
- Android Studio/SDK ve Unity Android Build Support
- ARCore destekli Android cihaz
- Android API seviyesi **28 veya üzeri**
- Unity Package Manager üzerinden projeyle birlikte gelen paketler:
  - AR Foundation `6.6.2`
  - ARCore XR Plugin `6.6.2`
  - Universal Render Pipeline `17.6.0`
  - Input System `1.20.1`

AR özellikleri Unity Editor’da sınırlı çalışır. Gerçek kamera ve takip
davranışını değerlendirmek için ARCore destekli fiziksel bir Android cihaz
kullanılmalıdır.

## Kurulum

1. Depoyu klonlayın.
2. Unity Hub üzerinden projeyi ekleyin.
3. Editor sürümü olarak `6000.6.7f1` seçin.
4. Proje açıldıktan sonra paketlerin ve asset’lerin import edilmesini bekleyin.
5. `File > Build Profiles` menüsünden Android platformunu seçin.
6. Android cihazda **USB debugging** özelliğini etkinleştirin ve cihazı
   bilgisayara bağlayın. / Uygulamayı direkt telefonunuza gönderip indirin ve kullanmaya başlayın

## Çalıştırma

1. `Assets/Scenes/HomeScreen.unity` sahnesini açın.
2. `File > Build Profiles > Build And Run` ile uygulamayı cihaza yükleyin.
3. Uygulama açıldığında ana menüden görüntülemek istediğiniz sahneyi seçin.
4. Kamera izni verildiğinde telefonu hareket ettirerek AR takibinin
   başlamasını bekleyin.
5. Gezegen, kameranın baktığı yönde ve varsayılan olarak yaklaşık 2 metre
   uzaklıkta görünür.
6. Yenileme kontrolü kullanıldığında AR oturumu sıfırlanır ve gezegen yeniden
   kameranın önüne yerleştirilir.

## Sahneler

| Sahne | Açıklama |
| --- | --- |
| `HomeScreen` | Gezegen ve güneş sistemi seçim ekranı |
| `Earth` | Dünya AR görünümü |
| `Mars` | Mars AR görünümü |
| `Jupiter` | Jüpiter AR görünümü |
| `Mercury` | Merkür AR görünümü |
| `Neptune` | Neptün AR görünümü |
| `Saturn` | Satürn AR görünümü |
| `Uranus` | Uranüs AR görünümü |
| `Venus` | Venüs AR görünümü |
| `Solar System` | Güneş ve gezegenlerin birlikte gösterimi |

Bu sahnelerin tamamı `ProjectSettings/EditorBuildSettings.asset` içinde
Android build listesine eklenmiştir. Uygulamanın başlangıç sahnesi
`HomeScreen`’dir.

## Proje yapısı

```text
Assets/
├── Scenes/       AR ve menü sahneleri
├── Scripts/      Sahne, dönüş, yörünge ve AR kontrol script’leri
└── Assets/       Font ve diğer görsel asset’ler
ProjectSettings/  Unity, Android ve build ayarları
Packages/         Unity Package Manager bağımlılıkları
```

Önemli script’ler:

- `SceneController.cs`: Sahne geçişi ve uygulamadan çıkış
- `ARRefreshController.cs`: AR oturumunun yenilenmesi ve gezegenin
  kameraya göre yerleştirilmesi
- `PlanetOrbit.cs`: Gezegen yörüngesi
- `OrbitLine.cs`: Yörünge çizgisinin oluşturulması
- `RotationController.cs`: Gezegen dönüşü

## Build

Android build almak için:

1. `File > Build Profiles` menüsünü açın.
2. Android platformunun seçili olduğundan emin olun.
3. Build Scenes listesinde `HomeScreen` ve diğer sahnelerin etkin olduğunu
   doğrulayın.
4. `Build` veya `Build And Run` seçeneğini kullanın.

## Lisans

Bu proje için ayrıca bir lisans dosyası tanımlanmamıştır. Kullanım ve dağıtım
koşulları için proje sahibine başvurun.

Feyza Gülen 
2023555402

