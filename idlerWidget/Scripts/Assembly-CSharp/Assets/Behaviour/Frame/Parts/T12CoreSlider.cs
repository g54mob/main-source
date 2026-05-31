using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12CoreSlider : MonoBehaviour
	{
		[SerializeField]
		private float _minY;

		[SerializeField]
		private float _maxY;

		[SerializeField]
		private float _rectractSpeed;

		[SerializeField]
		private SpriteRenderer _cylinderSprite;

		[SerializeField]
		private SpriteRenderer _iconSprite;

		[SerializeField]
		private Sprite[] _icons;

		[SerializeField]
		private Color[] _iconColors;

		private float _heightStart;

		private bool _dragging;

		private ActiveWorldFrame _parent;

		public int Solution { get; private set; } = -1;

		private void Awake()
		{
			_heightStart = _cylinderSprite.size.y;
		}

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		public void ButtonClicked(int idx)
		{
			if (idx == Solution)
			{
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				SetupPuzzle();
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Core Mismatch!");
				SetupPuzzle(idx);
			}
		}

		public void SetupPuzzle(int ignoreValue = -1)
		{
			int num;
			do
			{
				num = SeededRandom.Global.RandomRange(0, _icons.Length);
			}
			while (num == Solution || num == ignoreValue);
			Solution = num;
			_iconSprite.sprite = _icons[Solution];
			_iconSprite.color = _iconColors[Solution];
		}

		private void Update()
		{
			Vector3 localPosition = base.transform.localPosition;
			if (!_dragging)
			{
				localPosition.y = Mathf.Clamp(localPosition.y + _rectractSpeed * Time.deltaTime, _minY, _maxY);
				base.transform.localPosition = localPosition;
			}
			else
			{
				_dragging = false;
				localPosition.y = Mathf.Clamp(PlayerControls.MouseWorld.y - base.transform.parent.position.y - 0.5f, _minY, _maxY);
			}
			base.transform.localPosition = localPosition;
			_cylinderSprite.size = new Vector2(_cylinderSprite.size.x, 0f - (localPosition.y + _maxY + _heightStart));
		}

		private void OnMouseDrag()
		{
			_dragging = true;
		}
	}
}
