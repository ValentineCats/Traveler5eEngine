using System.Collections;
using System.Collections.Generic;
using System;

namespace Traveler5eEngine
{
    public class Skill
    {
        private string skillname;
        private bool proficient;
        private int ranks;
        private List<SubSkill> subskills;
        private List<AbilityScore> scores;


        /*
        private void Start()
        {

            this.skillname = this.name.ToLower();
            if (this.name.ToLower() != this.skillname)
            {
                Debug.Print("Names unequal " + this.name + " " + this.skillname);
            }
            subskills = this.GetComponentsInChildren<SubSkill>();

    }*/

        public Skill(string n, List<AbilityScore> ab, List<string> ss)
        {
            this.skillname = n;
            this.proficient = false;
            this.ranks = 0;
            this.scores = ab;
            this.subskills = new List<SubSkill>();

            int ssEnd = ss.Count;
            for (int i = 0; i < ssEnd; i++)
            {
                this.AddSubskill(ss[i]);
            }
        }

        public Skill(string n, List<AbilityScore> ab)
        {
            this.skillname = n;
            this.proficient = false;
            this.ranks = 0;
            this.scores = ab;
            this.subskills = null;
        }


        public void AddRanks(int r)
        {

            int i = r;
            if (this.proficient == false)
            {
                this.proficient = true;
                i--;
            }
            if (i > 0)
            {
                ranks += r;
            }
        }
        public void AddSubSkillRanks(string s, int r)
        {

            int i = r;
            if (this.proficient == false)
            {
                this.proficient = true;
                i--;
            }
            if (i > 0)
            {
                ranks += r;
            }
        }

        public int GetBonus()
        {

            try
            {
                if (this.proficient == false)
                {
                    return this.ranks + this.ChooseScore().GetBonus() - 2;
                }
                else
                {
                    return this.ranks + this.ChooseScore().GetBonus();
                }
            }
            catch (SubSkillNotFoundException ex)
            {
                throw ex;
            }
        }

        public List<SubSkill> GetSubskills()
        {
            return this.subskills;
        }

        public int GetBonus(string s)
        {
            try
            {
                if (this.proficient == false)
                {
                    return this.ranks + GetSubskillByName(s).GetRanks() + this.ChooseScore().GetBonus() - 2;
                }
                else
                {
                    return this.ranks + GetSubskillByName(s).GetRanks() + this.ChooseScore().GetBonus();
                }
            }
            catch (SubSkillNotFoundException ex)
            {
                throw ex;
            }


        }

        private AbilityScore ChooseScore()
        {
            int end = this.scores.Count;
            int max = 0;
            for (int i = 0; i < end; i++)
            {
                if (this.scores[i].GetBonus() > this.scores[max].GetBonus())
                {
                    max = i;
                }
            }
            return this.scores[max];
        }

        public int GetRanks()
        {
            return this.ranks;
        }

        public string GetName()
        {
            return this.skillname;
        }

        private SubSkill GetSubskillByName(string name)
        {
            int end = this.subskills.Count;
            int i;
            for (i = 0; i < end; i++)
            {
                if (name == this.subskills[i].GetSubSkillName())
                {

                    return this.subskills[i];
                }
            }
            throw new SubSkillNotFoundException("Unable to find subskill with name " + name);
        }



        public void AddSubskill(string n)
        {
            SubSkill sub = new SubSkill(n);
            subskills.Add(sub);

        }

    }



    [Serializable]
    public class SubSkillNotFoundException : Exception
    {

        public SubSkillNotFoundException(string danger)
            : base(danger)
        {

        }
    }
}