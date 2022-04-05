using System;

namespace Lesson_2._6
{
    internal class Program
    {
        public static Bank bankAccountCreation(Bank bankAccount)
        {
            Console.WriteLine("Создание счета.");

            Console.WriteLine("Каким образом вы хотите создать счет?");

            Console.WriteLine("1 - Счет по умолчанию.");

            Console.WriteLine("2 - Создать счет и выбрать его тип.");

            Console.WriteLine("3 - Создать счет и внести сумму в рублях на баланс.");

            Console.WriteLine("4 - Создать счет, выбрать его тип и внести сумму в выбранной валюте на баланс.");

            string UserChoice = string.Empty;

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":
                        bankAccount = new Bank(); return (bankAccount);
                    case "2":
                        int bankAccountType = Bank.bankTypeBankAccountCreate();

                        bankAccount = new Bank((float)bankAccountType);

                        Console.WriteLine("Счет успешно создан.");

                        return (bankAccount);

                    case "3":

                        int bankBalance = Bank.bankBalanceAccountCreate();

                        bankAccount = new Bank(bankBalance);

                        Console.WriteLine("Счет успешно создан.");

                        return (bankAccount);

                    case "4":
                        int accountType = Bank.bankTypeBankAccountCreate();

                        int balance = Bank.bankBalanceAccountCreate();

                        bankAccount = new Bank(balance, accountType);

                        Console.WriteLine("Счет успешно создан.");

                        return (bankAccount);

                    default:
                        Console.WriteLine("Введите команду корректно.");
                        break;
                }

            } while (true);


            

        }
        

        static void Main()
        {
            int numberOfAccounts = 0;

            Console.WriteLine("Введите число банковских счетов.");

            do
            {
                try
                {
                    numberOfAccounts = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");

                    continue;
                }
                if (numberOfAccounts < 0 || numberOfAccounts == 0)
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");
                }

            } while (numberOfAccounts == 0 || numberOfAccounts < 0);

            Bank[] bankAccounts = new Bank[numberOfAccounts];

            (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes = new (string AccountType, string ValueType)[numberOfAccounts];

            for (int i = 0; i < bankAccounts.Length; i++)
            {

                bankAccounts[i] = bankAccountCreation(bankAccounts[i]);

                Console.Clear();

            }

            string UserChoice = string.Empty;

            Console.WriteLine("Введите 'Посмотреть', чтобы посмотреть информацию о счете и его номер.");

            Console.WriteLine("Введите 'Снять', чтобы снять деньги со счета.");

            Console.WriteLine("Введите 'Перевести', чтобы перевести деньги с одного счета на другой.");

            Console.WriteLine("Введите 'Сравнить', чтобы сравнить тип аккаунтов и их баланс.");

            Console.WriteLine("Введите 'Очистить', чтобы очистить консоль.");

            Console.WriteLine("Введите 'Выход', чтобы выйти из приложения.");

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "Посмотреть":
                        Console.WriteLine("Введите номер аккаунта.");

                        try
                        {
                            int accountNumber = Convert.ToInt32(Console.ReadLine());

                            Bank.bankAccountGetInfo(bankAccounts, --accountNumber);

                        }
                        catch
                        {
                            Console.WriteLine("Введите существующий номер счета.");
                        }
                        break;
                    case "Снять":
                        try
                        {
                            Console.WriteLine("Введите номер счета, с которого хотите снять деньги.");

                            int BankAccountNum = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите сумму, которую хотите снять.");

                            int WithdrawSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            Bank.WithdrawMoney(bankAccounts, BankAccountNum, WithdrawSumOfMoney);

                        }
                        catch
                        {
                            Console.WriteLine("Введите существующий номер счета.");
                        }
                        break;
                    case "Перевести":
                        try
                        {
                            Console.WriteLine("Введите номер счета с которого вы хотите перевести сумму.");

                            int SourceBankAccount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите сумму, которую вы хотели бы перевести.");

                            int TransferSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите счет, на который вы хотели бы перевести сумму.");

                            int DestinationBankAccount = Convert.ToInt32(Console.ReadLine());

                            Bank.TransferMoney(bankAccounts, SourceBankAccount, DestinationBankAccount, TransferSumOfMoney);

                        }
                        catch
                        {
                            Console.WriteLine("Введите существующий номер счета.");
                        }
                        break;
                    case "Сравнить":
                        try
                        {
                            Console.WriteLine("Введите номер первого счета для сравнения.");

                            int FirstBankAccount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите номер второго счета для сравнения.");

                            int SecondBankAccount = Convert.ToInt32(Console.ReadLine());

                            if (Bank.Compare(bankAccounts, FirstBankAccount, SecondBankAccount))
                            {
                                Console.WriteLine("Счета соответсвуют.");
                            }else
                            {
                                Console.WriteLine("Счета не соответсвуют.");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Введите существующий номер счета.");
                        }
                        break;
                    case "Очистить":
                        Console.Clear();
                        break;
                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Введите запрос корректно.");
                        break;
                }
            } while (UserChoice != "Выход");

        }

    }

}
public class Bank
{
    public static void bankAccountGetInfo(Bank[] bank, int bankAccountNumber)
    {
        Console.WriteLine($"Номер счета: {bank[bankAccountNumber].BankAccountNumber}");

        Console.WriteLine($"Баланс: {bank[bankAccountNumber].Balance} {bank[bankAccountNumber].ValueType}");

        Console.WriteLine($"Тип счета: {bank[bankAccountNumber].AccountType}");
    }
    public static void WithdrawMoney(Bank[] bankAccounts, int BankAccountNum, int SumOfMoney)
    {

        for (int i = 0; i < bankAccounts.Length; i++)
        {
            if (bankAccounts[i].BankAccountNumber == BankAccountNum || bankAccounts[i].Balance >= SumOfMoney)
            {
                if (SumOfMoney <= 0)
                {
                    Console.WriteLine($"Вы не можете снять {SumOfMoney} {bankAccounts[i].ValueType}.");

                    return;
                }

                bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                Console.WriteLine($"Со счета {bankAccounts[i].BankAccountNumber} успешно снято {SumOfMoney} {bankAccounts[i].ValueType}. Остаток: {bankAccounts[i].Balance} {bankAccounts[i].ValueType}");

                return;

            }
            if (bankAccounts[i].BankAccountNumber - 1 == i)
            {
                Console.WriteLine("Счет не существует или на нем недостаточно средств.");
            }
        }

    }
    public static void TransferMoney(Bank[] bankAccounts, int SourceBankAccount, int DestinationBankAccount, int SumOfMoney)
    {

        for (int i = 0; i < bankAccounts.Length; i++)
        {
            if (bankAccounts[i].BankAccountNumber == SourceBankAccount && bankAccounts[i].Balance >= SumOfMoney)
            {
                Console.WriteLine("Введите счет, на который вы хотели бы перевести сумму.");

                for (int j = 0; j < bankAccounts.Length; j++)
                {
                    if (bankAccounts[j].BankAccountNumber == DestinationBankAccount && bankAccounts[i].ValueType == bankAccounts[j].ValueType)
                    {
                        if (SumOfMoney <= 0)
                        {
                            Console.WriteLine($"Вы не можете перевести {SumOfMoney} {bankAccounts[i].ValueType}.");

                            return;
                        }

                        bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                        bankAccounts[j].Balance = bankAccounts[j].Balance + SumOfMoney;

                        Console.WriteLine($"На счет {bankAccounts[j].BankAccountNumber} успешно зачислено {SumOfMoney} {bankAccounts[j].ValueType}. Баланс: {bankAccounts[j].Balance} {bankAccounts[j].ValueType}");
                        return;
                    }
                    if (j == bankAccounts.Length - 1)
                    {
                        Console.WriteLine("Введенный счет получения не существует или вы пытаетесь перевести деньги на счета разной валютности.");
                        return;
                    }
                }
            }
            if (bankAccounts.Length - 1 == i)
            {
                Console.WriteLine("Счет не существует или на нем недостаточно средств.");
                return;
            }
        }
    }

    public static bool Compare(Bank[] bankAccounts, int FirstBankAccount, int SecondBankAccount)
    {
        for (int i = 0; i < bankAccounts.Length; i++)
        {
            for (int j = 0; j < bankAccounts.Length; j++)
            {
                if (bankAccounts[i].BankAccountNumber == FirstBankAccount && bankAccounts[j].BankAccountNumber == SecondBankAccount)
                {
                    return bankAccounts[i] == bankAccounts[j];
                }
            }
        }
        return false;
    }
    private enum BankAccountInfo
    {
        bankAccountTypeRub = 1,

        bankAccountTypeBudget = 2,

        bankAccountTypeUsd = 3
    }

    public int BankAccountNumber;

    public int Balance;

    public int BankAccountType;

    public string ValueType;

    public string AccountType;

    public static int LastBankAccountNumber;

    public static int BankAccountNumberEnumerater()
    {
        if (LastBankAccountNumber == 0)
        {
            Random random = new Random();

            LastBankAccountNumber = random.Next(40000000, 50000000);
        }

        int BankAccountNumber = LastBankAccountNumber++;

        return BankAccountNumber;

    }
    public Bank()
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        Balance = 0;

        BankAccountType = (int)BankAccountInfo.bankAccountTypeRub;

        ValueType = "RUB";

        AccountType = "Рублевый";

    }
    public Bank(int Balance)
    {

        BankAccountNumber = BankAccountNumberEnumerater();

        this.Balance = Balance;

        BankAccountType = (int)BankAccountInfo.bankAccountTypeRub;

        ValueType = "RUB";

        AccountType = "Рублевый";

    }
    public Bank(float BankAccountType)
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        Balance = 0;

        if (BankAccountType == (int)BankAccountInfo.bankAccountTypeRub)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeRub;

            ValueType = "RUB";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeBudget)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeBudget;

            ValueType = "RUB";

            AccountType = "Бюджетный";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeUsd)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeUsd;

            ValueType = "USD";

            AccountType = "Валютный";
        }
    }
    public Bank(int Balance, int BankAccountType)
    {
        BankAccountNumber = BankAccountNumberEnumerater();

        this.Balance = Balance;

        if (BankAccountType == (int)BankAccountInfo.bankAccountTypeRub)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeRub;

            ValueType = "RUB";

            AccountType = "Рублевый";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeBudget)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeBudget;

            ValueType = "RUB";

            AccountType = "Бюджетный";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeUsd)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeUsd;

            ValueType = "USD";

            AccountType = "Валютный";
        }
    }
    
    public static int bankTypeBankAccountCreate()
    {
        Console.WriteLine("Введите тип счета, который вы хотели бы открыть.");

        Console.WriteLine("1 - Рублевый счет");

        Console.WriteLine("2 - Бюджетный счет.");

        Console.WriteLine("3 - Валютный счет.");

        do
        {
            try
            {
                int BankAccountType = Convert.ToInt32(Console.ReadLine());

                if (BankAccountType == 1 || BankAccountType == 2 || BankAccountType == 3)
                {
                    return BankAccountType;
                }
                else
                {
                    Console.WriteLine("Введите существующий тип счета.");

                    continue;
                }
            }
            catch
            {
                Console.WriteLine("Введите тип счета в корректном формате.");
            }


        } while (true);
    }
    public static int bankBalanceAccountCreate()
    {
        Console.WriteLine("Введите сумму, которую вы хотите внести на счет.");

        do
        {
            try
            {
                int SumOfRubles = Convert.ToInt32(Console.ReadLine());

                if (SumOfRubles < 0)
                {
                    Console.WriteLine("Вы не можете положить на счет отрицательную сумму.");

                    continue;
                }
                else
                {
                    return SumOfRubles;
                }
            }
            catch
            {
                Console.WriteLine("Введите сумму в корректном формате.");
            }
        } while (true);
    }

    public static bool operator ==(Bank First, Bank Second)
    {
        return (First.BankAccountType == Second.BankAccountType && First.Balance == Second.Balance);
    }
    public static bool operator !=(Bank first, Bank second)
    {
        return (first.BankAccountType != second.BankAccountType || first.Balance != second.Balance);
    }
    public bool Equals(Bank toCompareAccount)
    {
        return (Balance == toCompareAccount.Balance && BankAccountType == toCompareAccount.BankAccountType);
    }
    public override int GetHashCode()
    {
        int hashCode = LastBankAccountNumber - BankAccountNumber;

        return hashCode;
    }
    public override string ToString()
    {
        string bankAccountInfo = @$"Номер счета: {BankAccountNumber}
Баланс: {Balance} {ValueType}
Тип счета: {AccountType}";

        return bankAccountInfo;
    }
}

