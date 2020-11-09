using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class SRP_Bad_Example_AddUser
    {
        public void AddUser(string userName)
        {
            if (IsValid(userName))
            {
                Console.WriteLine("Kullanıcı Eklendi");
            }
            else
            {
                Console.WriteLine("Validasyon Hatası var");
            }
        }
        //Bu kullanıma bakarsak validasyon işlemi için başka bir yerde kullanıcı ekleyen bir classı kullanmamız gerekecek.Pek sağlıklı değil
        public bool IsValid(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return true;
        } //Validasyon kontrolünü yapan metot Kullanıcı ekleme classının içerisinde.Single Responsiblity prensibine aykırı bir durum
    }



    class SRP_Good_Example_AddUser
    {
        public void AddUser(string userName)
        {
            if (ValidationControl.IsValid(userName))
            {
                Console.WriteLine("Kullanıcı Eklendi");
            }
            else
            {
                Console.WriteLine("Validasyon Hatası var");
            }
        }
    }


    //Burada validasyon kontrolü yapacak classımızı ayırdık.Kullanılabilirliğini arttırmış olduk
    static class ValidationControl
    {
        public static bool IsValid(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return true;
        }
    }
}
