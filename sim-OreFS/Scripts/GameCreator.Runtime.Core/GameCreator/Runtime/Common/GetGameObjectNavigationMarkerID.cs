using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Marker by ID")]
	[Category("Navigation/Marker by ID")]
	[Image(typeof(IconID), ColorTheme.Type.TextNormal)]
	[Description("Reference to a scene Marker game object by its ID")]
	public class GetGameObjectNavigationMarkerID : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetString m_ID = new PropertyGetString();

		public override string String => $"Marker ID:{m_ID}";

		public override GameObject EditorValue
		{
			get
			{
				Marker[] array = UnityEngine.Object.FindObjectsByType<Marker>(FindObjectsSortMode.None);
				string text = m_ID.ToString();
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				int hashCode = text.GetHashCode();
				Marker[] array2 = array;
				foreach (Marker marker in array2)
				{
					if (((ISpatialHash)marker).UniqueCode == hashCode)
					{
						return marker.gameObject;
					}
				}
				return null;
			}
		}

		public override GameObject Get(Args args)
		{
			return GetObject(args);
		}

		private GameObject GetObject(Args args)
		{
			Marker markerByID = Marker.GetMarkerByID(m_ID.Get(args));
			if (!(markerByID != null))
			{
				return null;
			}
			return markerByID.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectNavigationMarkerID());
		}
	}
}
