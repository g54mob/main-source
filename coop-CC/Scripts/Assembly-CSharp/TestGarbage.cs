using System.Collections.Generic;
using UnityEngine;

public class TestGarbage : MonoBehaviour
{
	public class MyClass
	{
		public List<Entry> entries = new List<Entry>(2);
	}

	public struct Entry
	{
		public string a;

		public object b;

		public Entry(string a, object b)
		{
			this.a = a;
			this.b = b;
		}
	}

	private List<Dictionary<string, object>> _list = new List<Dictionary<string, object>>();

	private List<MyClass> _myClasses = new List<MyClass>();

	private void Update()
	{
		_list.Add(new Dictionary<string, object>
		{
			{ "difficulty", "Hard" },
			{ "runs_ran", 12 }
		});
		Dictionary<string, object> dictionary = new Dictionary<string, object>(2);
		dictionary["difficulty"] = "Hard";
		dictionary["runs_ran"] = 12;
		_list.Add(dictionary);
		MyClass myClass = new MyClass();
		myClass.entries.Add(new Entry("difficulty", "Hard"));
		myClass.entries.Add(new Entry("runs_ran", 12));
		_myClasses.Add(myClass);
	}
}
