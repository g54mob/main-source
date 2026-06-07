using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogTopic", menuName = "DialogTopics")]
public class DialogTopic : ScriptableObject
{
	public List<Dialog> dialogs = new List<Dialog>();
}
