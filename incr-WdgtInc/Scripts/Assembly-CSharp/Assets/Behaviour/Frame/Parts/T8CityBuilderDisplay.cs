using System.Numerics;
using Assets.Source.Player;
using Assets.Source.Util;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8CityBuilderDisplay : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _productivityDisplay;

		[SerializeField]
		private TMP_Text _partsDisplay;

		[SerializeField]
		private SpriteRenderer _progress;

		[SerializeField]
		private RectTransform _floatingTextPrefab;

		private float _updateTimer;

		private float _lastProgress;

		private void Update()
		{
			_updateTimer -= Time.deltaTime;
			if (_updateTimer < 0f)
			{
				_updateTimer = 0.5f;
				BigInteger inventoryCount = GamePlayer.Current.GetInventoryCount(GamePlayer.CityPartItem);
				BigInteger cityBuilderPartsCost = GamePlayer.Current.CityBuilderPartsCost;
				float num = GameMath.Clamp01(inventoryCount, cityBuilderPartsCost);
				if (num < _lastProgress)
				{
					UISounds.CraftFinished();
					Object.Instantiate(_floatingTextPrefab, FrameUI.Instance.transform).anchoredPosition = Camera.main.WorldToScreenPoint(_progress.transform.position + new UnityEngine.Vector3(7f, 0f));
				}
				_lastProgress = num;
				_productivityDisplay.TL("@T8CityBuilderBonus", GameMath.FormatPercentage(GamePlayer.Current.CityProductivityMultiplier, FormatPercentageMode.Offset, 2));
				_partsDisplay.TL("@T8CityBuilderProgress", BigInteger.Min(inventoryCount, cityBuilderPartsCost), GameMath.FormatNumber(cityBuilderPartsCost));
				_progress.size = new UnityEngine.Vector2(1f, 5.62f * num);
			}
		}
	}
}
