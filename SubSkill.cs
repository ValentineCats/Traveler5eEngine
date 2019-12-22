using System.Collections;
using System.Collections.Generic;


namespace Traveler5eEngine
{
    public class SubSkill
    {

        public string subskillname { get; set; }
        public int ranks { get; set; }
        //public Skill skill;

        public SubSkill(string n)
        {
            this.subskillname = n.ToLower();
            this.ranks = 0;
        }

        /*
        void Start()
        {

            this.subskillname = this.name.ToLower();
            if (this.name.ToLower() != this.subskillname)
            {
                Debug.Print("Names unequal " + this.name + " " + this.subskillname);
            }

        }*/

        public string GetSubSkillName()
        {
            return this.subskillname;
        }

        public int GetRanks()
        {
            return this.ranks;
        }

        public void AddRank(int i)
        {
            this.ranks += i;
            if (this.ranks < 0)
            {
                this.ranks = 0;
            }
        }

        public void AddRank(int i, int max)
        {
            if (max >= this.ranks)
            {
                return;
            }

            this.ranks += i;
            if (this.ranks < 0)
            {
                this.ranks = 0;
            }
        }


    }
}