using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{

    //BAD EXAMPLE

    class BadExample_ISP_DbContext_WithoutAddMetots : IBase_Bad_Context //Add metodunu kullanmayacak bir contexte Interface yapımız esnek olmadığı için zorunlu olarak Add metodunu eklemiş olduk.Açıkcası ilerleyen zamanlarda problemlere yol açacaktır.Eklediğimiz Add metodumuz haliyle boş kalacaktır
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            Console.WriteLine("Çağırma işlemi başarılı");
        }
    }

    class BadExample_ISP_DbContext_WithAddMetots : IBase_Bad_Context 
    {
        public void Add()
        {
            Console.WriteLine("Ekleme işlemi başarılı");
        }

        public void Get()
        {
            Console.WriteLine("Çağırma işlemi başarılı");
        }
    }


    interface IBase_Bad_Context
    {
        void Add();
        void Get();
    }

    //GOOD EXAMPLE

    class Goodxample_ISP_DbContext_WithoutAddMetots : IBase_Get //Sadece Get metodunu ekledik
    {
        
        public void Get()
        {
            Console.WriteLine("Çağırma işlemi başarılı");
        }
    }

    class GoodExample_ISP_DbContext_WithAddMetots : IBase_Good_Context //Her iki metodu da sorunsuz ekledik
    {
        public void Add()
        {
            Console.WriteLine("Ekleme işlemi başarılı");
        }

        public void Get()
        {
            Console.WriteLine("Çağırma işlemi başarılı");
        }
    }


    interface IBase_Good_Context:IBase_Get //Hem Add hem de Get metodunu kullacaklar için bir interface
    {
        void Add();
    }

    interface IBase_Get //Sadece get metoduna sahip olanlar için kullanılacak bir interface
    {
        void Get();
    }

}
