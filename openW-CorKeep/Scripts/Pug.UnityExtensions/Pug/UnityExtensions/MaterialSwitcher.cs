using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class MaterialSwitcher : MonoBehaviour
	{
		[Serializable]
		public class MaterialSwitcherToken
		{
			[NonSerialized]
			public MaterialSwitcher manager;

			public MonoBehaviour switchable;

			public Material material;

			public void Enable()
			{
				if (manager.activeToken != null)
				{
					manager.activeToken.switchable.enabled = false;
					manager.activeToken = null;
				}
				manager.spriteRenderer.material = material;
				if (!switchable.enabled)
				{
					switchable.enabled = true;
				}
				manager.activeToken = this;
			}
		}

		public SpriteRenderer spriteRenderer;

		public List<MaterialSwitcherToken> tokens;

		public MaterialSwitcherToken activeToken { get; private set; }

		public void Awake()
		{
			foreach (MaterialSwitcherToken token in tokens)
			{
				token.manager = this;
			}
		}

		public void Start()
		{
			tokens[0].Enable();
		}

		public MaterialSwitcherToken GetToken<T>()
		{
			return tokens.FirstOrDefault((MaterialSwitcherToken q) => q.switchable is T);
		}
	}
}
