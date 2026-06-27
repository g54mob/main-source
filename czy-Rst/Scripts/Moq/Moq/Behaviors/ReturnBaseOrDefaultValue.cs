using System;
using System.Linq;
using System.Reflection;

namespace Moq.Behaviors
{
	internal sealed class ReturnBaseOrDefaultValue : Behavior
	{
		private readonly Mock mock;

		public ReturnBaseOrDefaultValue(Mock mock)
		{
			this.mock = mock;
		}

		public override void Execute(Invocation invocation)
		{
			MethodInfo method = invocation.Method;
			if (mock.CallBase)
			{
				Type declaringType = method.DeclaringType;
				if (declaringType.IsInterface)
				{
					if (!mock.MockedType.IsInterface && mock.InheritedInterfaces.Contains<Type>(declaringType) && !method.IsEventAddAccessor() && !method.IsEventRemoveAccessor())
					{
						invocation.ReturnValue = invocation.CallBase();
						return;
					}
				}
				else if (!method.IsAbstract)
				{
					invocation.ReturnValue = invocation.CallBase();
					return;
				}
			}
			if (method.ReturnType != typeof(void))
			{
				Mock candidateInnerMock;
				object defaultValue = mock.GetDefaultValue(method, out candidateInnerMock);
				if (candidateInnerMock != null && invocation.MatchingSetup == null)
				{
					InnerMockSetup innerMockSetup = new InnerMockSetup(null, mock, MethodExpectation.CreateFrom(invocation), defaultValue);
					mock.MutableSetups.Add(innerMockSetup);
					innerMockSetup.Execute(invocation);
				}
				else
				{
					invocation.ReturnValue = defaultValue;
				}
			}
		}
	}
}
