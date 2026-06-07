using System;
using System.Collections.Generic;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class SceneEntries
	{
		[SerializeField]
		private List<SceneEntry> m_Entries = new List<SceneEntry>();

		public void Schedule(int scene, Args args)
		{
			foreach (SceneEntry entry in m_Entries)
			{
				Singleton<RoomManager>.Instance.Subscribe(scene, delegate
				{
					GameObject target = entry.GetTarget(args);
					Location location = entry.GetLocation(args);
					if (!(target == null))
					{
						Vector3 position = location.GetPosition(target);
						Quaternion rotation = location.GetRotation(target);
						Character character = target.Get<Character>();
						if (location.HasPosition(target))
						{
							if (character != null)
							{
								character.Driver.SetPosition(position);
							}
							else
							{
								target.transform.position = position;
							}
						}
						if (location.HasRotation(target))
						{
							if (character != null)
							{
								character.Driver.SetRotation(rotation);
							}
							else
							{
								target.transform.rotation = rotation;
							}
						}
					}
				});
			}
		}
	}
}
