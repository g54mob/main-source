using UnityEngine;

public class SerializationManager : MonoBehaviour
{
	private void Start()
	{
		SerializableFactory.RegisterInstantiator<SerializableClass>();
		SerializableFactory.RegisterInstantiator<SerializableSubclass>();
		byte[] buffer = new Serializer(new SerializableClass(254, bl: true, "Hello Serialization", 32, 3.14f)).Serialize();
		SerializableClass serializableClass = new Deserializer<SerializableClass>().Deserialize(buffer);
		Debug.Log("Byte: " + serializableClass.Byte);
		Debug.Log("Bool: " + serializableClass.Bool);
		Debug.Log("String: " + serializableClass.String);
		Debug.Log("Int: " + serializableClass.Int);
		Debug.Log("Float: " + serializableClass.Float);
		Debug.Log("SC1: " + serializableClass._subclass1.String);
		Debug.Log("SC1: " + serializableClass._subclass2.String);
	}
}
