using System;
using DV.Utils;

namespace DV.Customization.Gadgets
{
	public static class GadgetRaycastExtensions
	{
		public static PhysicsQueryBuilder.QueryResults FilterGadgetDepthHack(this PhysicsQueryBuilder.QueryResults queryResults)
		{
			return queryResults.FilterGadgetDepthHackGeneric((RaycastHitDV hit) => GadgetInteractor.TryGetTarget(hit, out var _));
		}

		public static PhysicsQueryBuilder.QueryResults FilterGadgetDepthHackGeneric(this PhysicsQueryBuilder.QueryResults queryResults, Predicate<RaycastHitDV> targetPredicate)
		{
			if (queryResults.Length < 2)
			{
				return queryResults;
			}
			RaycastHitDV firstHit = queryResults[0];
			if (TryGetGadgetWithinThreshold(out var index) && index != 0)
			{
				int length = queryResults.Length - index;
				Array.Copy(queryResults.UnderlyingArray, index, queryResults.UnderlyingArray, 0, length);
				queryResults = new PhysicsQueryBuilder.QueryResults(length);
			}
			return queryResults;
			bool TryGetGadgetWithinThreshold(out int reference)
			{
				for (int i = 0; i < queryResults.Length; i++)
				{
					RaycastHitDV obj = queryResults[i];
					reference = i;
					if (obj.distance > firstHit.distance + 0.08f)
					{
						return false;
					}
					if (targetPredicate(obj))
					{
						return true;
					}
				}
				reference = -1;
				return false;
			}
		}
	}
}
