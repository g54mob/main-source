using UnityEngine;

public class PolymorphicListTester : MonoBehaviour
{
	[PolymorphicList("List", typeof(TaskBase), "task")]
	public TaskList TaskList;
}
