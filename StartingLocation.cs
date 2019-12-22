using System.Collections;
using System.Collections.Generic;


namespace Traveler5eEngine
{
    public class StartingLocation
    {
        public Skill skill { get; set; }
        public string location { get; set; }

        public StartingLocation(string loc, Skill sk)
        {
            this.location = loc;
            this.skill = sk;
        }



        public Skill GetSkill()
        {
            return this.skill;
        }

        public string GetLocation()
        {
            return this.location;
        }





    }
}