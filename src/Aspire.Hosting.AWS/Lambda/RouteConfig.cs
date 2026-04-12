// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using System.Text.Json.Serialization;

namespace Aspire.Hosting.AWS.Lambda;

/// <summary>
/// Class representing the config for a Lambda function that the API Gateway emulator uses to figure out what method to call.
/// This class is populated AWS Aspire code and serialied to JSON and saved as environment variable to the API Gatway
/// emulator as part of the emulator's config.
/// </summary>
internal class RouteConfig
{
    internal RouteConfig(string lambdaResourceName, string endpoint, Method httpMethod, string path, string? integrationType = null)
    {
        LambdaResourceName = lambdaResourceName;
        Endpoint = endpoint;
        HttpMethod = httpMethod;
        Path = path;
        IntegrationType = integrationType;
    }

    public string LambdaResourceName { get; init; }

    public string Endpoint { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Method HttpMethod { get; init; }

    public string Path { get; init; }

    /// <summary>
    /// The integration type: "Lambda" (default) or "Http". When "Http", the request is proxied to the Endpoint URL instead of invoking a Lambda.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IntegrationType { get; init; }
}
