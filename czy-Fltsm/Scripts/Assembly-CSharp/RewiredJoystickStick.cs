using System;
using Rewired;
using UnityEngine;

[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Stick")]
public class RewiredJoystickStick : ScriptableObject
{
	[Flags]
	public enum Actions
	{
		None = 0,
		AxisXNegative = 1,
		AxisXPositive = 2,
		AxisYNegative = 4,
		AxisYPositive = 8
	}

	[Serializable]
	public struct Sprites
	{
		public Sprite AxisXNegative;

		public Sprite AxisXPositive;

		public Sprite AxisYNegative;

		public Sprite AxisYPositive;

		public Sprite AxisX;

		public Sprite AxisY;

		public Sprite All;
	}

	[SerializeField]
	private int _identifierX;

	[SerializeField]
	private int _identifierY = 1;

	[SerializeField]
	private Sprites _icons;

	[SerializeField]
	private Sprites _glyphs;

	[NonSerialized]
	private Actions _actions;

	public void Reset()
	{
		_actions = Actions.None;
	}

	public bool TryAddAction(ActionElementMap aem)
	{
		if (aem.elementIdentifierId == _identifierX)
		{
			AddAction(aem, Actions.AxisXNegative, Actions.AxisXPositive);
		}
		else
		{
			if (aem.elementIdentifierId != _identifierY)
			{
				return false;
			}
			AddAction(aem, Actions.AxisYNegative, Actions.AxisYPositive);
		}
		return true;
	}

	public override string ToString()
	{
		Sprite sprite = _actions switch
		{
			Actions.AxisXNegative => _glyphs.AxisXNegative, 
			Actions.AxisXPositive => _glyphs.AxisXPositive, 
			Actions.AxisYNegative => _glyphs.AxisYNegative, 
			Actions.AxisYPositive => _glyphs.AxisYPositive, 
			Actions.AxisXNegative | Actions.AxisXPositive => _glyphs.AxisX, 
			Actions.AxisYNegative | Actions.AxisYPositive => _glyphs.AxisY, 
			Actions.None => null, 
			_ => _glyphs.All, 
		};
		if ((bool)sprite)
		{
			return $"<sprite=\"{sprite.texture.name}\" sprite name=\"{sprite.name}\">";
		}
		return "WHOOPS!";
	}

	private void AddAction(ActionElementMap aem, Actions negative, Actions positive)
	{
		switch (aem.axisRange)
		{
		case AxisRange.Negative:
			_actions |= negative;
			break;
		case AxisRange.Positive:
			_actions |= positive;
			break;
		case AxisRange.Full:
			_actions |= negative | positive;
			break;
		default:
			throw new NotImplementedException();
		}
	}
}
