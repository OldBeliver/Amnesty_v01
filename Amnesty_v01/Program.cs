using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty_v01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Paperwork paperwork = new Paperwork();
            paperwork.Punishment();
        }
    }

    class Paperwork
    {
        private List<Prisoner> _prisoners;

        public Paperwork()
        {
            _prisoners = new List<Prisoner>();

            LoadListOfPrisoners();
        }

        private void LoadListOfPrisoners()
        {
            _prisoners.Add(new Prisoner("Пестель, Павел Иванович", "полковник Вятского пехотного полка", Crime.IntentToRegicide));
            _prisoners.Add(new Prisoner("Рылеев, Кондратий Фёдорович", "отставной подпоручик", Crime.IntentToRegicide));
            _prisoners.Add(new Prisoner("Муравьёв-Апостол, Сергей Иванович", "подполковник Черниговского пехотного полка", Crime.IntentToRegicide));
            _prisoners.Add(new Prisoner("Бестужев-Рюмин Михаил Павлович", "подпоручик Полтавского пехотного полка", Crime.IntentToRegicide));
            _prisoners.Add(new Prisoner("Каховский, Пётр Григорьевич", "отставной поручик", Crime.IntentToRegicide));
            _prisoners.Add(new Prisoner("Князь Трубецкой, Сергей Петрович", "полковник", Crime.Political));
            _prisoners.Add(new Prisoner("Князь Оболенский, Евгений Петрович", "поручик лейб-гвардии Финляндского полка", Crime.Political));
            _prisoners.Add(new Prisoner("Муравьёв-Апостол, Матвей Иванович", "отставной подполковник Полтавского пехотного полка", Crime.Political));
            _prisoners.Add(new Prisoner("Борисов, Пётр Иванович (Пётр Борисов 2-й)", "подпоручик 8-й артиллерийской бригады", Crime.Political));
            _prisoners.Add(new Prisoner("Борисов, Андрей Иванович (Андрей Борисов 1-й)", "отставной подпоручик", Crime.Schismatic));
            _prisoners.Add(new Prisoner("Горбачевский, Иван Иванович", "подпоручик 8-й артиллерийской бригады", Crime.Political));
            _prisoners.Add(new Prisoner("Спиридов, Михаил Матвеевич", "майор Пензенского пехотного полка", Crime.Political));
            _prisoners.Add(new Prisoner("Князь Барятинский, Александр Петрович", "штабс-ротмистр лейб-гвардии Гусарского полка", Crime.Corruption));
            _prisoners.Add(new Prisoner("Кюхельбекер, Вильгельм Карлович", "коллежский асессор", Crime.Political));
            _prisoners.Add(new Prisoner("Якубович, Александр Иванович", "капитан Нижегородского драгунского полка", Crime.Political));
            _prisoners.Add(new Prisoner("Поджио, Александр Викторович", "отставной подполковник Днепровского пехотного полка", Crime.Political));
            _prisoners.Add(new Prisoner("Муравьёв, Артамон Захарович", "полковник Ахтырского гусарского полка", Crime.Political));
            _prisoners.Add(new Prisoner("Вадковский, Фёдор Фёдорович", "прапорщик Нежинского конно-егерского полка", Crime.Political));
            _prisoners.Add(new Prisoner("Бечаснов, Владимир Александрович", "прапорщик 8-й артиллерийской бригады", Crime.Political));
            _prisoners.Add(new Prisoner("Давыдов, Василий Львович", "отставной полковник", Crime.Political));
            _prisoners.Add(new Prisoner("Юшневский, Алексей Петрович", "4-го класса, бывший генерал-интендант 2-й армии", Crime.Political));
            _prisoners.Add(new Prisoner("Бестужев, Александр Александрович", "штабс-капитан лейб-гвардии Драгунского полка", Crime.Political));
        }

        public void Punishment()
        {
            Console.WriteLine($"Высочайшим манифестом от 1 июня 1826 года был сформирован Верховный уголовный суд для суждения и вынесения приговора над участниками военного мятежа в декабре 1825 года в Санкт-Петербурге.");
            Console.WriteLine();
            Console.WriteLine($"Подсудимым построиться на перекличку");

            Console.WriteLine($"нажмите на ENTER для начала переклички");
            Console.ReadLine();

            var filteredOrderBy = _prisoners.OrderBy(prisoner => prisoner.Name);

            foreach (var prisoner in filteredOrderBy)
            {
                prisoner.ShowInfo();
                //Thread.Sleep(1500);
                //Console.Write($" - здесь, Ваша честь!\n");
                //Thread.Sleep(1000);
            }

            Console.WriteLine($"");
            Console.WriteLine($"Верховный уголовный суд, после обсуждения выводов ревизионной комиссии, определил меру наказания для каждого подсудимого. В заключение своей деятельности суд постановил приговоры о каждом подсудимом, которые и были представлены на Высочайшее утверждение.");
            Console.WriteLine();
            Console.WriteLine($"Лицам, имеющим судимость по статье \"политические\" - дарована жизнь, но лишены чинов и дворянства, и онные будут сосланы вечно на поселение в Сибирь.");
            Console.WriteLine();
            Console.WriteLine($"Лица, имеющие судимость по статье \"помышление цареубийства\" возвращаются в камеры для ожидания приговора путем четвертования");
            Console.WriteLine();
            Console.WriteLine($"нажмите на ENTER, чтобы зачитать список ожидающих приговор");
            Console.ReadLine();

            var nonAmnesty = _prisoners.Where(prisoner => prisoner.Crime != Crime.Political).ToList();

            foreach (var prisoner in nonAmnesty)
            {
                prisoner.ShowInfo();
            }

            Console.ReadKey();
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string Rank { get; private set; }
        public Crime Crime { get; private set; }


        public Prisoner(string name, string rank, Crime crime)
        {
            Name = name;
            Rank = rank;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Rank}");
        }
    }

    enum Crime
    {
        IntentToRegicide,
        Political,
        Corruption,
        Schismatic
    }
}
