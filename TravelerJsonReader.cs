using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Traveler5eEngine
{
    public class SkillTest
    {
        public string name { get; set; }
        public List<string> score { get; set; }
        public List<string> subskills { get; set; }
    }

    public class SkillsJson
    {
        public List<SkillTest> skillTest { get; set; }
    }

    public class AbilityScoresJson
    {
        public List<string> abilityScores { get; set; }
    }


    public class Homeland
    {
        public string home { get; set; }
        public string skill { get; set; }
    }

    public class HomelandsJson
    {
        public List<Homeland> homelands { get; set; }
    }


    public class TravelerJsonReader
    {
        private string skillsJsonPath;
        private string abilityScoresJsonPath;
        private string homelandJsonPath;
        private SkillsJson skillsJson;
        private AbilityScoresJson abilityScoresJson;
        private HomelandsJson homelandsJson;


        public CharacterLogicContainer clc;



        public TravelerJsonReader()
        {
            skillsJsonPath = "Assets/Resources/SkillsJson.json";
            abilityScoresJsonPath = "Assets/Resources/AbilityScoresJson.json";
            homelandJsonPath = "Assets/Resources/HomelandsJson.json";
            clc = new CharacterLogicContainer();
        }
        public void Begin()
        {
            
            var skilljson = File.ReadAllText(skillsJsonPath);
            var abilscorejson = File.ReadAllText(abilityScoresJsonPath);
            var homelandsjson = File.ReadAllText(homelandJsonPath);
            
            skillsJson = JsonSerializer.Deserialize<SkillsJson>(skilljson);
            abilityScoresJson = JsonSerializer.Deserialize<AbilityScoresJson>(abilscorejson);
            homelandsJson = JsonSerializer.Deserialize<HomelandsJson>(homelandsjson);

            this.InitializeAbilityScores();
            this.InitializeSkills();
            
            this.InitializeHomeland();
        }

        public void InitializeSkills()
        {

            int skillEnd = skillsJson.skillTest.Count;

            for (int i = 0; i < skillEnd; i++)
            {

                try
                {
                    if (skillsJson.skillTest[i].subskills != null)
                    {
                        clc.AddSkill(skillsJson.skillTest[i].name, skillsJson.skillTest[i].score, skillsJson.skillTest[i].subskills);
                    }
                    else
                    {
                        List<string> sskl = new List<string>();
                        clc.AddSkill(skillsJson.skillTest[i].name, skillsJson.skillTest[i].score, sskl);
                    }

                }
                catch (ScoreNotFoundException ex)
                {
                    //do something
                }

            }
        }

        public void InitializeHomeland()
        {
           
            
            try
            {
                int end = this.homelandsJson.homelands.Count;
                //StartingLocation star;
                for (int i = 0; i < end; i++)
                {
                    clc.AddHomeland(this.homelandsJson.homelands[i].home, this.homelandsJson.homelands[i].skill);
                }
            }
            catch (SkillNotFoundException ex)
            {
                //do something
            }
        }
        private void InitializeAbilityScores()
        {
            
            int end = abilityScoresJson.abilityScores.Count;


            for (int i = 0; i < end; i++)
            {
                clc.AddAbilityScore(abilityScoresJson.abilityScores[i], 10);

            }
            try
            {
                clc.RollAbilityScores(3, 0, 6);
            }
            catch (RandomRollFailed ex)
            {
                //do something
            }

        }
    }

    
}
