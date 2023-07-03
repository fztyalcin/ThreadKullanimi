using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* Hocam merhaba,
 Thread ile ilgili vermiş olduğunuz ödev üzerinde çalışıyorum ama galiba benim seviyemin çok üzerinde bir ödev oldu.
chat gpt ve bulabildiğim videolar üzerinden yola çıkarak aşağıdaki kodları yazabildim, yazdıklarımın ne olduğunu da biliyorum,
ancak daha önce görmediğim için yazdığım kodları nasıl çalıştıracağımı bilmiyorum.

KODLAR İLE İLGİLİ BİLGİLER.
- öncelikle bir queue koleksiyonu oluşturuldu.

- sonra queue dan okuma yapacağımız methodumuz oluşturuldu.

- daha sonra txt dosyamızdan okuma yapacağımız methodumuz oluşturuldu.

- queue dan okuma yapacak 5 thread için bir for döngüsü oluşturulup bu başlatıldı.
- queue okuması için methodumuz ise while döngüsü ile oluşturuldu ve buraya queue tamamlanmazsa diye şartımız tanımlandı.

- dosya okuması için yazılan method için ise masa üstünde bir klasörde oluşturduğum txt dosyamın yolunu yazdım.
- burada if else kullanıldı if içinde foreach döngüsünden faydalanıldı.
- dosya yolunda dosya varsa yapılacaklar ve olmadığı durumda yapılacaklar tanımlandı.

buradan sonrası nasıl ilerleyecek hiç bir fikrim yok.
*/



namespace ThreadKullanimi
{
    public class Program
    {
        static BlockingCollection<string> queue = new BlockingCollection<string>();
        static void Main(string[] args)
        {
            
            for (int i = 1;i<= 5;i++)
            {
                Thread thread = new Thread(ReadFromQueue);
                thread.Start();
            }
        }
        static void ReadFromQueue()
        {
            while (!queue.IsCompleted)
            {
                try
                {
                    string item = queue.Take();
                    Console.WriteLine(item + item.Length);
                    Thread.Sleep(3000);
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            
            }
        }
        static void ReadFromFile ()
        {
            string filePath = @"C:\Users\Yalçın ORUÇ\Desktop\Odevİcin\deneme.txt";

            if (File.Exists(filePath))
            {
                string [] metin = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding("windows-1254"));

                foreach (string line in metin)
                {
                    Console.WriteLine(line);
                }
            }
           else
            {
                Console.WriteLine("Dosya Bulunamadı :" +  filePath);
            }

            Console.ReadLine();
            
        }
        
    }
}
