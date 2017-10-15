﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Canada;
using Bogus;
using ConsoleDump;
using ServerForTheLogic.Utilities;
using ServerForTheLogic.Infrastructure;

namespace ServerForTheLogic
{
    /// <summary>
    /// Driver for the City Simulator program
    /// </summary>
    class Program
    {
        public static List<Person> People = new List<Person>();
        private const int MEAN_DEATH_AGE = 80;
        private const int STANDARD_DEVIATION_DEATH = 14;
        private static City city;
        private static Creator creator;

        /// <summary>
        /// Entry point for the city simulator program
        /// <para/> Last editted:  2017-10-02
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ////Person me = new Person();
            ////me.Dump();
            //Person me = new Person();
            //for (int i = 0; i < 24; i++) {
            //    me = new Person();
            //   // me.createPerson();
            //    People.Add(me);
            //    me = null;
            //}
            //People.Dump();
            //me = new Person();
            //// me.KeepOpen();
            //KeepOpen();

            //TEST DATA 
            city = new City();
            creator = new Creator();
            //fill 3 blocks
            Block b = creator.addRoadsToEmptyBlock(new Point(52, 56), city);
            Block b1 = creator.addRoadsToEmptyBlock(new Point(56, 56), city);
            Block b2 = creator.addRoadsToEmptyBlock(new Point(0, 0), city);
            b.setBlockType();
            b1.setBlockType();
            b2.setBlockType();
            //stick some buildings in them blocks
            creator.createBuilding(city, b);
            creator.createBuilding(city, b1);
            creator.createBuilding(city, b2);
            creator.createBuilding(city, b1);
            creator.createBuilding(city, b);

            //sets the adjacent blocks of the specified block
            foreach (Block block in city.blockMap)
            {
                city.setAdjacents(block);
            }
            Console.WriteLine("expand");
            city.expandCity();
            
            printCity();

            KeepOpen();
        }
        /// <summary>
        /// Keeps the program running 
        /// <para/> Last editted:  2017-10-02
        /// </summary>
        public static void KeepOpen()
        {
            while (true) ;
        }

        /// <summary>
        /// Prints a block represented as symbols/letters in a neatly formatted manner
        /// <para/> Last editted:  2017-10-02
        /// </summary>
        /// <param name="b"></param>
        public static void printBlock(Block b)
        {
            for (int i = 0; i < Block.BLOCK_WIDTH; i++)
            {
                for (int j = 0; j < Block.BLOCK_LENGTH; j++)
                {
                    if (b.LandPlot[i, j] != null)
                    {
                        Console.Write(b.LandPlot[i, j].Type);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the city represented as symbols/letters in a neatly formatted manner
        /// <para/> Last editted:  2017-10-02
        /// </summary>
        public static void printCity()
        {
            for (int i = 0; i < City.CITY_WIDTH; ++i)
            {
                for (int j = 0; j < City.CITY_LENGTH; ++j)
                {
                    if (city.map[i, j] != null)
                    {
                        Console.Write(city.map[i, j].Type);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }


    }
}
