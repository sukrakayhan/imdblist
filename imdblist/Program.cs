using System; // Sistem kütüphanesini içe aktar
using System.Collections.Generic; // List kullanabilmek için koleksiyonları içe aktar

// Film sınıfı, her bir film nesnesinin özelliklerini tanımlar
class Film
{
    public string Ismi { get; set; } // Filmin ismi
    public double ImdbPuani { get; set; } // Filmin IMDB puanı

    // Yapıcı metod (constructor). Yeni bir Film nesnesi oluşturmak için çağrılır.
    public Film(string ismi, double imdbPuani)
    {
        Ismi = ismi;
        ImdbPuani = imdbPuani;
    }
}

class Program
{
    static void Main()
    {
        // Önceden tanımlanmış filmleri içeren film listesi oluşturuluyor.
        List<Film> filmListesi = new List<Film>
        {
            new Film("The Shawshank Redemption", 9.3),
            new Film("The Godfather", 9.2),
            new Film("The Dark Knight", 9.0),
            new Film("Pulp Fiction", 8.9),
            new Film("Forrest Gump", 8.8),
            
        };

        while (true) // Sonsuz döngü başlatılıyor.
        {
            Console.WriteLine("\nYeni bir film eklemek ister misiniz? (evet/hayır)");
            string cevap = Console.ReadLine().ToLower(); // Kullanıcının cevabı okunuyor ve küçük harfe dönüştürülüyor.

            if (cevap == "hayır") // Eğer kullanıcı "hayır" dediyse döngüden çıkılır.
                break;

            if (cevap == "evet") // Kullanıcı yeni film eklemek isterse:
            {
                Console.WriteLine("Film Adı:");
                string yeniFilmAdi = Console.ReadLine(); // Kullanıcıdan film adı alınıyor.

                Console.WriteLine("IMDB Puanı:");
                double yeniImdbPuani;

                while (!double.TryParse(Console.ReadLine(), out yeniImdbPuani))
                {
                    /* Kullanıcıdan alınan IMDB puanı geçerli bir sayıya dönüştürülemiyorsa,
                     tekrar giriş yapmasını istiyoruz */
                    Console.WriteLine("Lütfen geçerli bir sayı girin.");
                    Console.WriteLine("IMDB Puanı:");
                }

                /* Yeni filmi mevcut filme ekle */
                filmListesi.Add(new Film(yeniFilmAdi, yeniImdbPuani));
            }
        }

        /* Bütün filmleri listeleme kısmı */
        Console.WriteLine("\nBütün Filmler:");

        foreach (var film in filmListesi)
        {
            /* Her filmi isim ve IMDB puanı ile yazdırıyoruz */
            Console.WriteLine($"{film.Ismi} - {film.ImdbPuani}");
        }


        /* IMDB puanı 4 ile 9 arasında olan filmleri filtreleme kısmı */
        Console.WriteLine("\nIMDB puanı 4 ile 9 arasında olan Filmler:");

        foreach (var film in filmListesi)
        {
            /* Eğer filmin IMDB puanı belirtilen aralıkta ise yazdırıyoruz */
            if (film.ImdbPuani >= 4 && film.ImdbPuani <= 9)
            {
                Console.WriteLine($"{film.Ismi} - {film.ImdbPuani}");
            }
        }

        /* İsimleri 'A' ile başlayan filmleri filtreleme kısmı */
        Console.WriteLine("\nİsimi 'A' harfiyle başlayan Filmler:");

        foreach (var film in filmListesi)
        {
            /* Eğer filmin ismini kontrol ediyoruz ve büyük-küçük harf duyarsızlığı sağlamak için ToUpper() metodu kullanılıyor*/
            if (film.Ismi.ToUpper().StartsWith('A'))
            {
                Console.WriteLine($"{film.Ismi} - {film.ImdbPuani}");
              }
        }
    }
}