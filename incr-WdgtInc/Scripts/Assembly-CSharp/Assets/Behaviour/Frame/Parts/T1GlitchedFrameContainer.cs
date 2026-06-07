using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1GlitchedFrameContainer : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _background;

		[SerializeField]
		private List<Sprite> _backgroundSprites;

		[SerializeField]
		private FrameRecipeItem _item1;

		[SerializeField]
		private FrameRecipeItem _item2;

		private float _backgroundTimer;

		private float _recipeTimer;

		private ActiveWorldFrame _parent;

		private void OnEnable()
		{
			_parent = GetComponent<ActiveWorldFrame>();
			_backgroundTimer = 0f;
			_recipeTimer = 0f;
			Update();
		}

		private void Update()
		{
			_backgroundTimer -= Time.deltaTime;
			_recipeTimer -= Time.deltaTime;
			if (_backgroundTimer < 0f)
			{
				_background.sprite = SeededRandom.Global.Choose(_backgroundSprites);
				_backgroundTimer = SeededRandom.Global.RandomRange(3.5f, 8f);
				_background.flipY = SeededRandom.Global.RandomBool();
			}
			if (!(_recipeTimer < 0f))
			{
				return;
			}
			bool flag = false;
			foreach (KeyValuePair<ItemType, BigInteger> reagent in ((T1GlitchedFrame)_parent.ActiveFrame).GetReagents())
			{
				if (!flag && reagent.Key.Identifier.EndsWith("widget"))
				{
					_item2.SetItem(reagent.Key, (int)reagent.Value);
					flag = true;
				}
				else
				{
					_item1.SetItem(reagent.Key, (int)reagent.Value);
				}
			}
			_recipeTimer = 0.5f;
		}
	}
}
