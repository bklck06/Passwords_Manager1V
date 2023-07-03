using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager
{
    class Program
    {
        static Dictionary<string, string> passwords = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            bool Nero = true;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            while (Nero)
            {
                Console.Write("----- Product by. Neron V -----");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("____________________________________");
                Console.WriteLine("|  Lütfen bir seçenek girin:       |");
                Console.WriteLine("| {}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{} |");
                Console.WriteLine("|  1 - Şifreleri listele           |");
                Console.WriteLine("|  2 - Şifre ekle                  |");
                Console.WriteLine("|  3 - Şifre sil                   |");
                Console.WriteLine("|  4 - Şifre güncelle              |");
                Console.WriteLine("|  5 - Şifreleri temizle           |");
                Console.WriteLine("|  6 - Şifreleri masaüstüne kaydet |");
                Console.WriteLine("| {}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{} |");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");

                Console.Write("Seçiminizi yapın (1-6):");
                
                

                string choiceString = Console.ReadLine();
                int choice = int.Parse(choiceString);

                switch (choice)
                {
                    case 1:
                        
                        foreach (var item in passwords)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        break;
                    case 2:
                        
                        Console.Write("Hesap adı: ");
                        string account = Console.ReadLine();
                        Console.Write("Şifre: ");
                        string password = Console.ReadLine();
                        passwords.Add(account, password);
                        break;
                    case 3:
                        
                        Console.Write("Silinecek hesap adı: ");
                        string deleteAccount = Console.ReadLine();
                        passwords.Remove(deleteAccount);
                        break;
                    case 4:
                        
                        Console.Write("Güncellenecek hesap adı: ");
                        string updateAccount = Console.ReadLine();
                        Console.Write("Yeni şifre: ");
                        string newPassword = Console.ReadLine();
                        passwords[updateAccount] = newPassword;
                        break;
                    case 5:
                        
                        passwords.Clear();
                        break;
                    case 6:
                        
                        using (StreamWriter writer = new StreamWriter("passwords.txt", true))
                        {
                            foreach (var item in passwords)
                            {
                                writer.WriteLine($"{item.Key}: {item.Value}");
                            }
                        }
                        Console.WriteLine("Şifreler masaüstüne kaydedildi.");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçenek.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Programdan çıkılıyor...");
        }

        static void ListPasswords()
        {
            Console.WriteLine("Kayıtlı Şifreler:");
            foreach (var item in passwords)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        static void AddPassword()
        {
            Console.Write("Hesap adı: ");
            string account = Console.ReadLine();
            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            passwords.Add(account, password);
            Console.WriteLine("Yeni şifre eklendi.");
        }

        static void ShowPassword()
        {
            Console.Write("Hesap adı: ");
            string account = Console.ReadLine();

            if (passwords.ContainsKey(account))
            {
                Console.WriteLine($"Şifre: {passwords[account]}");
            }
            else
            {
                Console.WriteLine("Hesap bulunamadı.");
            }
        }

        static void DeletePassword()
        {
            Console.Write("Hesap adı: ");
            string account = Console.ReadLine();

            if (passwords.ContainsKey(account))
            {
                passwords.Remove(account);
                Console.WriteLine("Şifre silindi.");
            }
            else
            {
                Console.WriteLine("Hesap bulunamadı.");
            }
        }
    }
}
