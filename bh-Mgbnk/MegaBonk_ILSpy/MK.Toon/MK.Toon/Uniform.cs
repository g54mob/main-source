using UnityEngine;

namespace MK.Toon;

public class Uniform
{
	protected string _name;

	protected int _id;

	public string name => _name;

	public int id => _id;

	public Uniform(string name)
	{
		_name = name;
		int num = Shader.PropertyToID(name);
		_id = num;
	}
}
