
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace VanillaAnimalsExpandedRoyal
{
	public class ThinkNode_Peacock : ThinkNode_Conditional
	{


		protected override bool Satisfied(Pawn pawn)
		{
			if (pawn.def == InternalDefOf.VAERoy_Peacock)
			{
				return true;
			}
			return false;
		}
	}
}
