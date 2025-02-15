﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Webapp.SeedData
{

    public class SeedObject
    {
        public Library[] library { get; set; }
        public User[] users { get; set; }
        public Archetype[] archetypes { get; set; }
        public Pitch[] pitches { get; set; }
    }

    public class Library
    {
        public string version { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public Level[] levels { get; set; }
    }

    public class Level
    {
        public int level { get; set; }
        public string description { get; set; }
        public string[] holders { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string tokenAuth { get; set; }
        public string pic { get; set; }
        public Badge[] badges { get; set; }
        public bool admin { get; set; }
    }

    public class Badge
    {
        public string name { get; set; }
        public string level { get; set; }
    }

    public class Archetype
    {
        public string name { get; set; }
        public Badge[] badges { get; set; }
    }



    public class Pitch
    {
        public string username { get; set; }
        public string badgeName { get; set; }
        public string oldLevel { get; set; }
        public string pitchedLevel { get; set; }
        public string pitchMessage { get; set; }
        public Holder[] holders { get; set; }
        public string timestamp { get; set; }
    }

    public class Holder
    {
        public string name { get; set; }
        public string message { get; set; }
        public bool pitchStatus { get; set; }
    }

}
