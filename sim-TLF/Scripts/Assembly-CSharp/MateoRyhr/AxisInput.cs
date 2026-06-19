namespace MateoRyhr
{
	public class AxisInput : BasicInput, IFloat
	{
		public float FloatValue
		{
			get
			{
				return GetValue();
			}
			set
			{
				FloatValue = value;
			}
		}

		private float GetValue()
		{
			return _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<float>();
		}
	}
}
