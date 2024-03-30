using System.Collections.Generic;

namespace Client
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonType> Types { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
    }
}


