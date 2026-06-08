using System;
using KitchenData;
using KitchenData.Localisations;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	[RequireComponent(typeof(TextMeshPro))]
	public class AutoLocal : MonoBehaviour
	{
		public enum LocalisationType
		{
			Name = 0,
			Description = 1
		}

		public LocalisationType Type;

		public GenericLocalisation Localisation;

		private TextMeshPro _Target;

		private TextMeshPro Target
		{
			get
			{
				if (_Target != null)
				{
					return _Target;
				}
				try
				{
					_Target = GetComponent<TextMeshPro>();
					if (_Target == null)
					{
						return null;
					}
				}
				catch (Exception arg)
				{
					Debug.LogWarning($"{base.gameObject.GetGameObjectPath()} {arg}");
				}
				return _Target;
			}
		}

		private void Awake()
		{
			Set(Localisation);
		}

		public void SetColour(Color colour)
		{
			if ((bool)Target)
			{
				Target.color = colour;
			}
		}

		public void Set(GenericLocalisation localisation)
		{
			if (localisation == null)
			{
				return;
			}
			Localisation = localisation;
			try
			{
				if (!(Target == null))
				{
					TextMeshPro target = Target;
					target.text = Type switch
					{
						LocalisationType.Name => Localisation.Name, 
						LocalisationType.Description => Localisation.Description, 
						_ => Target.text, 
					};
				}
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"{base.gameObject.GetGameObjectPath()} {arg}");
			}
		}

		public void Set(GenericLocalisationStruct localisation)
		{
			try
			{
				if (!(Target == null))
				{
					TextMeshPro target = Target;
					target.text = Type switch
					{
						LocalisationType.Name => localisation.Name, 
						LocalisationType.Description => localisation.Description, 
						_ => Target.text, 
					};
				}
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"{arg}");
			}
		}
	}
}
