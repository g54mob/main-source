using System;
using System.ComponentModel;
using Moq.Language;
using Moq.Language.Flow;

namespace Moq.Protected
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IProtectedMock<TMock> : IFluentInterface where TMock : class
	{
		IProtectedAsMock<TMock, TAnalog> As<TAnalog>() where TAnalog : class;

		ISetup<TMock> Setup(string voidMethodName, params object[] args);

		ISetup<TMock> Setup(string voidMethodName, bool exactParameterMatch, params object[] args);

		ISetup<TMock> Setup(string voidMethodName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args);

		ISetup<TMock, TResult> Setup<TResult>(string methodOrPropertyName, params object[] args);

		ISetup<TMock, TResult> Setup<TResult>(string methodOrPropertyName, bool exactParameterMatch, params object[] args);

		ISetup<TMock, TResult> Setup<TResult>(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args);

		ISetupGetter<TMock, TProperty> SetupGet<TProperty>(string propertyName);

		ISetupSetter<TMock, TProperty> SetupSet<TProperty>(string propertyName, object value);

		ISetupSequentialAction SetupSequence(string methodOrPropertyName, params object[] args);

		ISetupSequentialAction SetupSequence(string methodOrPropertyName, bool exactParameterMatch, params object[] args);

		ISetupSequentialAction SetupSequence(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args);

		ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, params object[] args);

		ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, bool exactParameterMatch, params object[] args);

		ISetupSequentialResult<TResult> SetupSequence<TResult>(string methodOrPropertyName, Type[] genericTypeArguments, bool exactParameterMatch, params object[] args);

		void Verify(string methodName, Times times, params object[] args);

		void Verify(string methodName, Type[] genericTypeArguments, Times times, params object[] args);

		void Verify(string methodName, Times times, bool exactParameterMatch, params object[] args);

		void Verify(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args);

		void Verify<TResult>(string methodName, Times times, params object[] args);

		void Verify<TResult>(string methodName, Type[] genericTypeArguments, Times times, params object[] args);

		void Verify<TResult>(string methodName, Times times, bool exactParameterMatch, params object[] args);

		void Verify<TResult>(string methodName, Type[] genericTypeArguments, Times times, bool exactParameterMatch, params object[] args);

		void VerifyGet<TProperty>(string propertyName, Times times);

		void VerifySet<TProperty>(string propertyName, Times times, object value);
	}
}
