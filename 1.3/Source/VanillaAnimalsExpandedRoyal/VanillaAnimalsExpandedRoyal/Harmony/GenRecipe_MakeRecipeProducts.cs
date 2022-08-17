using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace VanillaAnimalsExpandedRoyal
{




    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("MakeRecipeProducts")]

    public static class VanillaAnimalsExpandedRoyal_GenRecipe_MakeRecipeProducts_Patch
    {
        static List<ThingDef> allowedMeals = new List<ThingDef>() { InternalDefOf.MealSimple,InternalDefOf.MealFine,InternalDefOf.MealFine_Meat };

        public static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, RecipeDef recipeDef)
        {
            List<Thing> resultingList = values.ToList();
            if (recipeDef.products != null)
            {
                foreach (Thing thing in resultingList)
                {
                    if (allowedMeals.Contains(thing.def))
                    {
                        CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
                        if (compIngredients != null)
                        {
                            if (compIngredients.ingredients.Contains(InternalDefOf.VAERoy_QuailMeat))
                            {
                                if(thing.def!= InternalDefOf.MealFine_Meat)
                                {
                                    thing.def = InternalDefOf.MealLavish;
                                }
                                else thing.def = InternalDefOf.MealLavish_Meat;

                            }
                        }
                    }
                    
                }

            }
            return resultingList;



          
            




        }

    }





}
