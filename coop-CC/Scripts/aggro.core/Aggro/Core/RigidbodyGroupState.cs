namespace Aggro.Core
{
	public struct RigidbodyGroupState
	{
		public double timestamp;

		public ValueTypeList4<RigidbodyGroupEntryState> group;

		public static RigidbodyGroupState Interpolate(in RigidbodyGroupState a, in RigidbodyGroupState b, float t)
		{
			RigidbodyGroupState result = default(RigidbodyGroupState);
			for (int i = 0; i < a.group.Count; i++)
			{
				RigidbodyGroupEntryState a2 = a.group[i];
				RigidbodyGroupEntryState b2 = b.group[i];
				result.group.Add(RigidbodyGroupEntryState.Interpolate(in a2, in b2, t));
			}
			return result;
		}
	}
}
