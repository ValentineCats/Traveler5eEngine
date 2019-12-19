using System.Collections;
using System.Collections.Generic;
using System;

namespace Traveler5eEngine
{
    public class AbilityScores
    {
        //string[] names;
        //int[] scores;
        //int[] maximums;
        public List<AbilityScore> abilityScores;
        //public GameObject abilityScoreContainerObject;

        public AbilityScores()
        {
            abilityScores = new List<AbilityScore>();
        }


        public void AddAbilityScore(string name, int score)
        {
            // this.gameObject.transform.GetChild(0).gameObject.AddComponent<AbilityScore>();
            // GameObject o = Instantiate(abilityScoreContainerObject, new Vector3(0,0,0), Quaternion.identity);
            //o.transform.parent = this.gameObject.transform;

            //o.GetComponent<AbilityShim>().Initialize(n);
            AbilityScore abilityScore = new AbilityScore(name, score);
            //abilityScore.Initialize(name);
            abilityScores.Add(abilityScore);
        }

        public void IncreaseScoreByName(string n, int sco)
        {
            int x;
            try
            {
                x = GetListLocName(n).IncreaseScore(sco);

            }
            catch (ScoreNotFoundException ex)
            {
                throw ex;
            }

        }



        public int GetBonusByName(string n)
        {
            int x;
            try
            {
                x = GetListLocName(n).GetBonus();

            }
            catch (ScoreNotFoundException ex)
            {
                throw ex;
            }
            return x;
        }



        private int GetScoreIntByName(string n)
        {
            int x;
            try
            {
                x = GetListLocName(n).GetScore();

            }
            catch (ScoreNotFoundException ex)
            {
                throw ex;
            }
            return x;
        }

        //utility that find the score by name. Used by many other methods
        public AbilityScore GetListLocName(string n)
        {
            int end = this.abilityScores.Count;
            int i;
            for (i = 0; i < end; i++)
            {
                if (n.ToLower() == this.abilityScores[i].GetName().ToLower())
                {

                    return this.abilityScores[i];
                }
            }
            throw new ScoreNotFoundException("Unable to find score with name " + n);

        }


        public void SetScoreByName(string n, int sco)
        {
            GetListLocName(n).SetScore(sco);
            //Debug.Print("Ability Score " + n + " not found");
        }

        public List<AbilityScore> GetScores()
        {
            return this.abilityScores;
        }
    }

    /*
    [Serializable]
    public class ScoreNotFoundException : Exception
    {

        public ScoreNotFoundException(string danger)
            : base(danger)
        {

        }
    }*/

}