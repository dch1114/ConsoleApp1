using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    struct Item
    {
        public bool equip;
        public string Name;
        public int deffense;
        public int attack;
        public int gold;
        public string Explain;
        public string Effect;

        public void Inventory()
        {
            if (deffense != 0)
            {
                if (equip == true)
                {
                    Console.WriteLine($"-[E] {Name}\t | 방어력 + {deffense}\t | {Explain} ");
                }
                else
                {
                    Console.WriteLine($"- {Name}\t | 방어력 + {deffense}\t | {Explain} ");
                }
            }
            else
            {
                if (equip == true)
                {
                    Console.WriteLine($"-[E] {Name}\t | 공격력  + {attack}\t | {Explain} ");
                }
                else
                {
                    Console.WriteLine($"- {Name}\t | 공격력 + {attack}\t | {Explain} ");
                }
            }
        }
    }

    struct Character
    {
        public int level;
        public int attack;
        public int defense;
        public int Hp;
        public int gold;
        public string name;
    }

    internal class Program
    {
        static Character ch = new Character();

        static void Inventory()
        {
            Item[] items = new Item[3];
            items[0].equip = true; items[0].Name = "무쇠갑옷"; items[0].deffense = 5; items[0].attack = 0; items[0].Explain = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            items[1].equip = true; items[1].Name = "스파르타의 창"; items[1].attack = 7; items[1].deffense = 0; items[1].Explain = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            items[2].equip = false; items[2].Name = "낡은 검"; items[2].attack = 2; items[2].deffense = 0; items[2].Explain = "쉽게 볼 수 있는 낡은 검입니다.";

            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < items.Length; i++)
            {
                items[i].Inventory();
            }

            while (true)
            {
                Console.Write("\n");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                string input = Console.ReadLine();
                int num1 = int.Parse(input);

                if (num1 == 0)
                {
                    MainMenu();
                }
                else if (num1 == 1)
                {
                    isequip(items);
                }
            }
        }

        static void isequip(Item[] items)
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < items.Length; i++)
            {
                items[i].Inventory();
            }
        }

        static void State()
        {
            ch.level = 01;
            ch.name = "Chad ( 전사 )";
            ch.attack = 10;
            ch.defense = 5;
            ch.Hp = 100;
            ch.gold = 1500;

            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv : {0}", ch.level);
            Console.WriteLine("{0}", ch.name);
            Console.WriteLine("공격력 : {0}", ch.attack);
            Console.WriteLine("방어력 : {0}", ch.defense);
            Console.WriteLine("체력 : {0}", ch.Hp);
            Console.WriteLine("Gold : {0}\n", ch.gold);
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            int num1 = int.Parse(input);

            if (num1 == 0)
            {
                MainMenu();
            }
            else
            {
                State();
            }
        }

        static void store()
        {
            Item[] items = new Item[6];
            items[0].equip = false; items[0].Name = "수련자 갑옷"; items[0].attack = 0; items[0].deffense = 5; items[0].Explain = "수련에 도움을 주는 갑옷입니다."; items[0].gold = 1000;
            items[1].equip = false; items[1].Name = "무쇠갑옷"; items[1].attack = 0; items[1].deffense = 9; items[1].Explain = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            items[2].equip = false; items[2].Name = "스파르타의 갑옷"; items[2].attack = 2; items[2].deffense = 15; items[2].Explain = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."; items[2].gold = 3500;
            items[3].equip = false; items[3].Name = "낡은 검"; items[3].attack = 2; items[3].deffense = 0; items[3].Explain = "쉽게 볼 수 있는 낡은 검입니다."; items[3].gold = 600;
            items[4].equip = false; items[4].Name = "청동 도끼"; items[4].attack = 5; items[4].deffense = 0; items[4].Explain = "어디선가 사용됐던거 같은 도끼입니다."; items[4].gold = 1500;
            items[5].equip = false; items[5].Name = "스파르타의 창"; items[5].attack = 7; items[5].deffense = 0; items[5].Explain = "스파르타의 전사들이 사용했다는 전설의 창입니다.";

            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드]\n{ch.gold} G\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].deffense != 0 && items[i].attack == 0)
                {
                    Console.WriteLine($"{items[i].Name} | 방어력 + {items[i].deffense} | {items[i].Explain} | {items[i].gold} G");
                }
                else if (items[i].attack != 0 && items[i].deffense == 0)
                {
                    Console.WriteLine($"{items[i].Name} | 공격력 + {items[i].attack} | {items[i].Explain} | {items[i].gold} G");
                }
                else
                {
                    Console.WriteLine($"{items[i].Name} | 방어력 + {items[i].deffense} | 공격력 + {items[i].attack} | {items[i].Explain} | {items[i].gold} G");
                }
            }

            Console.Write("\n");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            int num1 = int.Parse(input);

            if (num1 == 0)
            {
                MainMenu();
            }
            else if (num1 == 1)
            {
                isbuy(items);
            }

            static void isbuy(Item[] items)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드]\n{ch.gold} G\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].deffense != 0 && items[i].attack == 0)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].Name} | 방어력 + {items[i].deffense} | {items[i].Explain} | {items[i].gold} G");
                    }
                    else if (items[i].attack != 0 && items[i].deffense == 0)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].Name} | 공격력 + {items[i].attack} | {items[i].Explain} | {items[i].gold} G");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {items[i].Name} | 방어력 + {items[i].deffense} | 공격력 + {items[i].attack} | {items[i].Explain} | {items[i].gold} G");
                    }
                }
                Console.Write("\n");
                Console.WriteLine("0. 나가기\n");
            }
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            while (true)
            {
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        State();
                        break;
                    case "2":
                        Inventory();
                        break;
                    case "3":
                        store();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}

/*

구현이 어려웠던 것
1. 장착 관리
2. 상점 > 아이템 구매에 들어가는데 메인 함수에 작성된 상태보기와 인벤토리 상점이 왜 뜨는지 모르겠습니다
결국 기능적인 구현을 못한것 같습니다 ㅠㅠ

*/