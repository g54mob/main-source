using UnityEngine;

namespace TH20
{
	public class ScriptableObjectWithID : ScriptableObject, IObjectWithID
	{
		[SerializeField]
		private int _id;

		int IObjectWithID.ID
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}
	}
}
