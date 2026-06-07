using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[CreateAssetMenu(fileName = "New FootstepMaterial", menuName = "Footstepper/Footstep Material")]
	public class FootstepMaterial : ScriptableObject
	{
		[Tooltip("The default effect is used when the footstepper doesn't use an effect tag or no matching tag is defined in the tag effects.")]
		public FootstepEffect defaultEffect = new FootstepEffect();

		[Tooltip("The effect of the matching tag is used if the footstepper defined an effect tag.\nYou can use tags to create different effects for e.g. 'heavy' and 'light' footsteppers.\nTags must be unique, you can't define effects with the same tag.")]
		public List<FootstepTagEffect> tagEffects = new List<FootstepTagEffect>();

		private Dictionary<string, FootstepEffect> lookup;

		protected virtual Dictionary<string, FootstepEffect> Lookup
		{
			get
			{
				if (lookup == null)
				{
					lookup = new Dictionary<string, FootstepEffect>();
					for (int i = 0; i < tagEffects.Count; i++)
					{
						lookup.Add(tagEffects[i].tag, tagEffects[i].effect);
					}
				}
				return lookup;
			}
		}

		public virtual FootstepEffect GetEffect(string effectTag)
		{
			if (tagEffects.Count > 0 && Lookup.TryGetValue(effectTag, out var value))
			{
				return value;
			}
			return defaultEffect;
		}
	}
}
