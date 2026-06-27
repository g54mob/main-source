using System.Collections.Generic;
using Restory.Data.Identifications;
using UnityEngine;

namespace Restory.EventSystems.ExitEvents
{
	[CreateAssetMenu(fileName = "ExitEventSettings", menuName = "Restory/ExitEvents/ExitEventSettings")]
	public class ExitEventSettings : ScriptableObject
	{
		[SerializeField]
		private List<ExitEventSettingsData> entries;

		public IReadOnlyList<ExitEventSettingsData> Entries => entries;

		private void OnValidate()
		{
			ValidateSettings();
		}

		private void ValidateSettings()
		{
			HashSet<UniqueIdentificator> hashSet = new HashSet<UniqueIdentificator>();
			foreach (ExitEventSettingsData entry in entries)
			{
				if (entry == null)
				{
					Debug.LogError("entries contains empty entry");
				}
				else
				{
					if (!entry.Identificator)
					{
						continue;
					}
					if (!hashSet.Add(entry.Identificator))
					{
						Debug.LogError("entries contains duplicate identificator " + entry.Identificator.ID);
						continue;
					}
					if (entry.LayerOrder < 0)
					{
						Debug.LogError("entry has not valid LayerOrder" + $" {entry.LayerOrder}");
					}
					HashSet<UniqueIdentificator> hashSet2 = new HashSet<UniqueIdentificator>();
					foreach (UniqueIdentificator subordinate in entry.Subordinates)
					{
						if (!subordinate)
						{
							Debug.LogError("Subordinates contains empty identificator");
						}
						else if (subordinate == entry.Identificator)
						{
							Debug.LogError("Subordinates contains self identificator");
						}
						else if (!hashSet2.Add(subordinate))
						{
							Debug.LogError("Subordinates contains duplicate identificator " + subordinate.ID);
						}
					}
					HashSet<UniqueIdentificator> hashSet3 = new HashSet<UniqueIdentificator>();
					foreach (UniqueIdentificator incompatible in entry.Incompatibles)
					{
						if (!incompatible)
						{
							Debug.LogError("Incompatibles contains empty identificator");
						}
						else if (incompatible == entry.Identificator)
						{
							Debug.LogError("Incompatibles contains self identificator");
						}
						else if (!hashSet3.Add(incompatible))
						{
							Debug.LogError("Incompatibles contains duplicate identificator " + incompatible.ID);
						}
						else if (hashSet2.Contains(incompatible))
						{
							Debug.LogError("Incompatibles contains subordinate identificator " + incompatible.ID);
						}
					}
				}
			}
		}
	}
}
