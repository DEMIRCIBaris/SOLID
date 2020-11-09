using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    //BAD EXAMPLE

    class Bad_LSP_Example_HeadSet_WithoutMicrophone : Bad_Base_HeadSet
    {
        public override void SounIn() //Mikrofon olmadığı için bu classın böyle bir özelliği yok.Ama base classımız bu özelliği barındırdığı için metodun eklenmesi gerekti.İleride potansiyel olarak bir çok hataya sebebiyet verecektir.
        {
            throw new NotImplementedException();
        }

        public override void SounOut()
        {
            Console.WriteLine("Ses dışarıya veriliyor");
        }
    }

    class Bad_LSP_Example_HeadSet_WithMicrophone : Bad_Base_HeadSet
    {
        public override void SounIn()
        {
            Console.WriteLine("Ses mikrofona aktarılıyor");
        }

        public override void SounOut()
        {
            Console.WriteLine("Ses dışarıya veriliyor");
        }
    }

    abstract class Bad_Base_HeadSet
    {
        public abstract void SounOut();
        public abstract void SounIn();
    }

    //GOOD EXAMPLE

    class Good_LSP_Example_HeadSet_WithoutMicrophone : Good_Base_HeadSet
    {
       
        public override void SounOut()
        {
            Console.WriteLine("Ses dışarıya veriliyor");
        }
    }

    class Good_LSP_Example_HeadSet_WithMicrophone : Good_Base_HeadSet, SoundIn_Interface //Diğer kulaklığımızda bu özelliğe sahip olduğu için interface implemente edildi
    {
        public void SoundIn()
        {
            Console.WriteLine("Ses mikrofona aktarılıyor");
        }

        public override void SounOut()
        {
            Console.WriteLine("Ses dışarıya veriliyor");
        }
    }

    abstract class Good_Base_HeadSet
    {
        public abstract void SounOut();//Her iki kulaklıkta da örnek olan özelliği base classımıza ekledik
    }

    interface SoundIn_Interface
    {
         void SoundIn();
    }
    

}
