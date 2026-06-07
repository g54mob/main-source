public class StoredScript
{
	public HighInstructionList m_Instructions;

	public string m_Name;

	public ObjectType m_Head;

	public StoredScript(HighInstructionList Instructions, string Name, ObjectType Head)
	{
		m_Instructions = Instructions;
		m_Name = Name;
		m_Head = Head;
	}
}
