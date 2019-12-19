using System.Collections;
using System.Collections.Generic;


namespace Traveler5eEngine
{
    public class Skills
    {

        private List<Skill> skills;

        public Skills()
        {
            skills = new List<Skill>();
        }

        public void AddSkill(string n, List<AbilityScore> s, List<string> ss)
        {
            skills.Add(new Skill(n, s, ss));
        }

        public Skill GetSkill(string n)
        {
            int end = skills.Count;
            for (int i = 0; i < end; i++)
            {
                if (skills[i].GetName() == n)
                {
                    return skills[i];
                }
            }
            return skills[0];
        }

        public List<Skill> GetSkills()
        {
            return this.skills;
        }


    }
}