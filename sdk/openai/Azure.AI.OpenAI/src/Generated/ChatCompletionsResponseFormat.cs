// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI
{
    /// <summary> The valid response formats Chat Completions can provide. Used to enable JSON mode. </summary>
    public readonly partial struct ChatCompletionsResponseFormat : IEquatable<ChatCompletionsResponseFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ChatCompletionsResponseFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ChatCompletionsResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";
        private const string JsonObjectValue = "json_object";

        /// <summary> Use the default, plain text response format. </summary>
        public static ChatCompletionsResponseFormat Text { get; } = new ChatCompletionsResponseFormat(TextValue);
        /// <summary>
        /// Use a response format that guarantees emission of a valid JSON object. Only structure is guaranteed and contents must
        /// still be validated.
        /// </summary>
        public static ChatCompletionsResponseFormat JsonObject { get; } = new ChatCompletionsResponseFormat(JsonObjectValue);
        /// <summary> Determines if two <see cref="ChatCompletionsResponseFormat"/> values are the same. </summary>
        public static bool operator ==(ChatCompletionsResponseFormat left, ChatCompletionsResponseFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ChatCompletionsResponseFormat"/> values are not the same. </summary>
        public static bool operator !=(ChatCompletionsResponseFormat left, ChatCompletionsResponseFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ChatCompletionsResponseFormat"/>. </summary>
        public static implicit operator ChatCompletionsResponseFormat(string value) => new ChatCompletionsResponseFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ChatCompletionsResponseFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ChatCompletionsResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
