public class RecordingAction
{
	public enum Action
	{
		Create = 0,
		Move = 1,
		Special = 2,
		Destroy = 3,
		ShowPlot = 4,
		ChangeTile = 5,
		Total = 6
	}

	public Action m_Action;

	public RecordingStamp m_Stamp;

	public int m_UID;

	public ObjectType m_Type;

	public int m_Index;

	public int m_X;

	public int m_Y;

	public int m_Rotation;

	public int m_OldX;

	public int m_OldY;

	public int m_OldRotation;

	public object m_SpecialData;

	public object m_OldSpecialData;
}
