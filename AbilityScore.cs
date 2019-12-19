using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.IO;


namespace Traveler5eEngine
{
    [Serializable]
    public class AbilityScore
    {
        public string scoreName { get; set; }
        public int score { get; set; }
        public int bonus { get; set; }
        public int maximum { get; set; }
        //testing

        public AbilityScore(string n, int s)
        {
            this.scoreName = n;
            this.score = s;
            this.maximum = 20;
            this.CalculateBonus();
        }

        public void Initialize(string name)
        {
            this.scoreName = name;
            this.score = 10;
            this.bonus = 0;
            this.maximum = 20;
        }

        public int IncreaseScore(int b)
        {
            if (this.score + b > this.maximum)
            {
                this.maximum += 2;
                Debug.Print("Score " + this.GetName() + "'s maximum will be increased by 2 because " + (this.GetScore() + b) + " > " + this.GetMax());
                return this.score;

            }
            else
            {
                this.score += b;
                this.CalculateBonus();
                Debug.Print("Score " + this.GetName() + " " + this.score + " will be increased by " + b);
                return this.score;
            }

        }

        //public void Get()

        public void SetScore(int s)
        {
            this.score = s;
            this.CalculateBonus();
        }

        public int GetBonus()
        {
            return this.bonus;
        }

        public int GetScore()
        {
            return this.score;
        }

        public int GetScoreValue()
        {
            return this.score;
        }

        public string GetName()
        {
            return this.scoreName;
        }

        public int GetMax()
        {
            return this.maximum;
        }

        public void CalculateBonus()
        {
            this.bonus = (this.score - 10) / 2;
        }
    }
}
