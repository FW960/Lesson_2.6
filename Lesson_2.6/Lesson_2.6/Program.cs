using System;

namespace Lesson_2._6
{
    internal class Program
    {
        public static Bank bankAccountCreation(Bank bankAccount)
        {
            Console.WriteLine("�������� �����.");

            Console.WriteLine("����� ������� �� ������ ������� ����?");

            Console.WriteLine("1 - ���� �� ���������.");

            Console.WriteLine("2 - ������� ���� � ������� ��� ���.");

            Console.WriteLine("3 - ������� ���� � ������ ����� � ������ �� ������.");

            Console.WriteLine("4 - ������� ����, ������� ��� ��� � ������ ����� � ��������� ������ �� ������.");

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

                        Console.WriteLine("���� ������� ������.");

                        return (bankAccount);

                    case "3":

                        int bankBalance = Bank.bankBalanceAccountCreate();

                        bankAccount = new Bank(bankBalance);

                        Console.WriteLine("���� ������� ������.");

                        return (bankAccount);

                    case "4":
                        int accountType = Bank.bankTypeBankAccountCreate();

                        int balance = Bank.bankBalanceAccountCreate();

                        bankAccount = new Bank(balance, accountType);

                        Console.WriteLine("���� ������� ������.");

                        return (bankAccount);

                    default:
                        Console.WriteLine("������� ������� ���������.");
                        break;
                }

            } while (true);


            

        }
        

        static void Main()
        {
            int numberOfAccounts = 0;

            Console.WriteLine("������� ����� ���������� ������.");

            do
            {
                try
                {
                    numberOfAccounts = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("������� ����� ���������� ������ � ���������� �������.");

                    continue;
                }
                if (numberOfAccounts < 0 || numberOfAccounts == 0)
                {
                    Console.WriteLine("������� ����� ���������� ������ � ���������� �������.");
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

            Console.WriteLine("������� '����������', ����� ���������� ���������� � ����� � ��� �����.");

            Console.WriteLine("������� '�����', ����� ����� ������ �� �����.");

            Console.WriteLine("������� '���������', ����� ��������� ������ � ������ ����� �� ������.");

            Console.WriteLine("������� '��������', ����� �������� ��� ��������� � �� ������.");

            Console.WriteLine("������� '��������', ����� �������� �������.");

            Console.WriteLine("������� '�����', ����� ����� �� ����������.");

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "����������":
                        Console.WriteLine("������� ����� ��������.");

                        try
                        {
                            int accountNumber = Convert.ToInt32(Console.ReadLine());

                            Bank.bankAccountGetInfo(bankAccounts, --accountNumber);

                        }
                        catch
                        {
                            Console.WriteLine("������� ������������ ����� �����.");
                        }
                        break;
                    case "�����":
                        try
                        {
                            Console.WriteLine("������� ����� �����, � �������� ������ ����� ������.");

                            int BankAccountNum = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("������� �����, ������� ������ �����.");

                            int WithdrawSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            Bank.WithdrawMoney(bankAccounts, BankAccountNum, WithdrawSumOfMoney);

                        }
                        catch
                        {
                            Console.WriteLine("������� ������������ ����� �����.");
                        }
                        break;
                    case "���������":
                        try
                        {
                            Console.WriteLine("������� ����� ����� � �������� �� ������ ��������� �����.");

                            int SourceBankAccount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("������� �����, ������� �� ������ �� ���������.");

                            int TransferSumOfMoney = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("������� ����, �� ������� �� ������ �� ��������� �����.");

                            int DestinationBankAccount = Convert.ToInt32(Console.ReadLine());

                            Bank.TransferMoney(bankAccounts, SourceBankAccount, DestinationBankAccount, TransferSumOfMoney);

                        }
                        catch
                        {
                            Console.WriteLine("������� ������������ ����� �����.");
                        }
                        break;
                    case "��������":
                        try
                        {
                            Console.WriteLine("������� ����� ������� ����� ��� ���������.");

                            int FirstBankAccount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("������� ����� ������� ����� ��� ���������.");

                            int SecondBankAccount = Convert.ToInt32(Console.ReadLine());

                            if (Bank.Compare(bankAccounts, FirstBankAccount, SecondBankAccount))
                            {
                                Console.WriteLine("����� ������������.");
                            }else
                            {
                                Console.WriteLine("����� �� ������������.");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("������� ������������ ����� �����.");
                        }
                        break;
                    case "��������":
                        Console.Clear();
                        break;
                    case "�����":
                        break;
                    default:
                        Console.WriteLine("������� ������ ���������.");
                        break;
                }
            } while (UserChoice != "�����");

        }

    }

}
public class Bank
{
    public static void bankAccountGetInfo(Bank[] bank, int bankAccountNumber)
    {
        Console.WriteLine($"����� �����: {bank[bankAccountNumber].BankAccountNumber}");

        Console.WriteLine($"������: {bank[bankAccountNumber].Balance} {bank[bankAccountNumber].ValueType}");

        Console.WriteLine($"��� �����: {bank[bankAccountNumber].AccountType}");
    }
    public static void WithdrawMoney(Bank[] bankAccounts, int BankAccountNum, int SumOfMoney)
    {

        for (int i = 0; i < bankAccounts.Length; i++)
        {
            if (bankAccounts[i].BankAccountNumber == BankAccountNum || bankAccounts[i].Balance >= SumOfMoney)
            {
                if (SumOfMoney <= 0)
                {
                    Console.WriteLine($"�� �� ������ ����� {SumOfMoney} {bankAccounts[i].ValueType}.");

                    return;
                }

                bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                Console.WriteLine($"�� ����� {bankAccounts[i].BankAccountNumber} ������� ����� {SumOfMoney} {bankAccounts[i].ValueType}. �������: {bankAccounts[i].Balance} {bankAccounts[i].ValueType}");

                return;

            }
            if (bankAccounts[i].BankAccountNumber - 1 == i)
            {
                Console.WriteLine("���� �� ���������� ��� �� ��� ������������ �������.");
            }
        }

    }
    public static void TransferMoney(Bank[] bankAccounts, int SourceBankAccount, int DestinationBankAccount, int SumOfMoney)
    {

        for (int i = 0; i < bankAccounts.Length; i++)
        {
            if (bankAccounts[i].BankAccountNumber == SourceBankAccount && bankAccounts[i].Balance >= SumOfMoney)
            {
                Console.WriteLine("������� ����, �� ������� �� ������ �� ��������� �����.");

                for (int j = 0; j < bankAccounts.Length; j++)
                {
                    if (bankAccounts[j].BankAccountNumber == DestinationBankAccount && bankAccounts[i].ValueType == bankAccounts[j].ValueType)
                    {
                        if (SumOfMoney <= 0)
                        {
                            Console.WriteLine($"�� �� ������ ��������� {SumOfMoney} {bankAccounts[i].ValueType}.");

                            return;
                        }

                        bankAccounts[i].Balance = bankAccounts[i].Balance - SumOfMoney;

                        bankAccounts[j].Balance = bankAccounts[j].Balance + SumOfMoney;

                        Console.WriteLine($"�� ���� {bankAccounts[j].BankAccountNumber} ������� ��������� {SumOfMoney} {bankAccounts[j].ValueType}. ������: {bankAccounts[j].Balance} {bankAccounts[j].ValueType}");
                        return;
                    }
                    if (j == bankAccounts.Length - 1)
                    {
                        Console.WriteLine("��������� ���� ��������� �� ���������� ��� �� ��������� ��������� ������ �� ����� ������ ����������.");
                        return;
                    }
                }
            }
            if (bankAccounts.Length - 1 == i)
            {
                Console.WriteLine("���� �� ���������� ��� �� ��� ������������ �������.");
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

        AccountType = "��������";

    }
    public Bank(int Balance)
    {

        BankAccountNumber = BankAccountNumberEnumerater();

        this.Balance = Balance;

        BankAccountType = (int)BankAccountInfo.bankAccountTypeRub;

        ValueType = "RUB";

        AccountType = "��������";

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

            AccountType = "���������";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeUsd)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeUsd;

            ValueType = "USD";

            AccountType = "��������";
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

            AccountType = "��������";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeBudget)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeBudget;

            ValueType = "RUB";

            AccountType = "���������";
        }
        else if (BankAccountType == (int)BankAccountInfo.bankAccountTypeUsd)
        {
            this.BankAccountType = (int)BankAccountInfo.bankAccountTypeUsd;

            ValueType = "USD";

            AccountType = "��������";
        }
    }
    
    public static int bankTypeBankAccountCreate()
    {
        Console.WriteLine("������� ��� �����, ������� �� ������ �� �������.");

        Console.WriteLine("1 - �������� ����");

        Console.WriteLine("2 - ��������� ����.");

        Console.WriteLine("3 - �������� ����.");

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
                    Console.WriteLine("������� ������������ ��� �����.");

                    continue;
                }
            }
            catch
            {
                Console.WriteLine("������� ��� ����� � ���������� �������.");
            }


        } while (true);
    }
    public static int bankBalanceAccountCreate()
    {
        Console.WriteLine("������� �����, ������� �� ������ ������ �� ����.");

        do
        {
            try
            {
                int SumOfRubles = Convert.ToInt32(Console.ReadLine());

                if (SumOfRubles < 0)
                {
                    Console.WriteLine("�� �� ������ �������� �� ���� ������������� �����.");

                    continue;
                }
                else
                {
                    return SumOfRubles;
                }
            }
            catch
            {
                Console.WriteLine("������� ����� � ���������� �������.");
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
        string bankAccountInfo = @$"����� �����: {BankAccountNumber}
������: {Balance} {ValueType}
��� �����: {AccountType}";

        return bankAccountInfo;
    }
}

