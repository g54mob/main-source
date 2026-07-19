using System.Linq;
using System.Reflection;

namespace UniGLTF
{
	public class PartialExtensionBase<T> : JsonSerializableBase
	{
		public int __count => (from x in typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where x.GetCustomAttributes(typeof(JsonSerializeMembersAttribute), inherit: true).Any()
			select x).Count();

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			MethodInfo[] methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.GetCustomAttributes(typeof(JsonSerializeMembersAttribute), inherit: true).Any())
				{
					object[] parameters = new GLTFJsonFormatter[1] { f };
					methodInfo.Invoke(this, parameters);
				}
			}
		}
	}
}
