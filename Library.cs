namespace C__LAB7_LIBRARY
{
    public class MyAttribute : Attribute
    {
        public string Comment { get; set; }
        public MyAttribute() { }
        public MyAttribute(string Comment)
        {
            this.Comment = Comment;
        }
    }

    [MyAttribute("Базовый класс Animal для всех животных")]
    public abstract class Animal
    {
        public string Country { get; set; }
        public string HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }
        public string classification { get; set; }
        public string favourite_food { get; set; }
        public Animal(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food)
        {
            this.Country = Country;
            this.HideFromOtherAnimals = HideFromOtherAnimals;
            this.Name = Name;
            this.WhatAnimal = WhatAnimal;
            this.classification = classification.ToString();
            this.favourite_food = favourite_food.ToString();
        }

        public void Deconstruct(out string country, out string hideFromOtherAnimals, out string name, out string whatAnimal)
        {
            country = Country;
            hideFromOtherAnimals = HideFromOtherAnimals;
            name = Name;
            whatAnimal = WhatAnimal;
        }

        public virtual void GetClassificationAnimal() { }
        public virtual void GetFavouriteFood() { }
        public virtual void SayHello() { }
    }


    [MyAttribute("Производный от Animal класс Cow")]
    public class Cow : Animal
    {
        public Cow(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }
        public override void SayHello()
        {
            Console.WriteLine("moooooo");
        }
    }


    [MyAttribute("Производный от Animal класс Lion")]
    public class Lion : Animal
    {
        public Lion(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }
        public override void SayHello()
        {
            Console.WriteLine("grrrrrrr");
        }
    }


    [MyAttribute("Производный от Animal класс Pig")]
    public class Pig : Animal
    {
        public Pig(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food) : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }
        public override void SayHello()
        {
            Console.WriteLine("oink-oink");
        }
    }


    [MyAttribute("Перечисление классификаций животных")]
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }


    [MyAttribute("Перечисление любимой еды животных")]
    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }
}
