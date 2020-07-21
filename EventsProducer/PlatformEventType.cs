using System.ComponentModel;

namespace EventsProducer
{
    public enum PlatformEventType
    {
        [Description("Test.ModelDefinition.Created")]
        ModelDefinitionCreated,

        [Description("Test.ModelDefinition.Updated")]
        ModelDefinitionUpdated,

        [Description("Test.ModelDefinition.Deleted")]
        ModelDefinitionDeleted,

        [Description("Test.TypeDefinition.Created")]
        TypeCreated,

        [Description("Test.TypeDefinition.Updated")]
        TypeUpdated,

        [Description("Test.TypeDefinition.Deleted")]
        TypeDeleted,

        [Description("Test.ObjectModel.Created")]
        ObjectModelCreated,

        [Description("Test.ObjectModel.Updated")]
        ObjectModelUpdated,

        [Description("Test.ObjectModel.Deleted")]
        ObjectModelDeleted,

        [Description("Test.ObjectModel.Extension.Created")]
        ObjectModelExtensionCreated,

        [Description("Test.ObjectModel.Extension.Updated")]
        ObjectModelExtensionUpdated,

        [Description("Test.ObjectModel.Reference.Created")]
        ReferenceCreated,

        [Description("Test.ObjectModel.Reference.Updated")]
        ReferenceUpdated,

        [Description("Test.ObjectModel.Reference.Deleted")]
        ReferenceDeleted,

        [Description("Test.ObjectModel.Method.Invoked")]
        MethodInvoked,

        [Description("Test.ObjectModel.File.Uploaded")]
        ObjectModelFileUploaded,

        [Description("Test.ObjectModel.File.Deleted")]
        ObjectModelFileDeleted,

        [Description("Test.File.Uploaded")]
        FileUploaded,

        [Description("Test.File.Deleted")]
        FileDeleted,

        [Description("Test.FunctionDefinition.Created")]
        FunctionDefinitionCreated,

        [Description("Test.FunctionDefinition.Updated")]
        FunctionDefinitionUpdated,

        [Description("Test.FunctionDefinition.Deleted")]
        FunctionDefinitionDeleted,

        [Description("Test.AlarmDefinition.Created")]
        AlarmDefinitionCreated,

        [Description("Test.EventDefinition.Created")]
        EventDefinitionCreated,

        [Description("Test.Device.Created")]
        DeviceCreated,

        [Description("Test.Device.Updated")]
        DeviceUpdated,

        [Description("Test.Device.Deleted")]
        DeviceDeleted,

        [Description("Test.App.Created")]
        AppCreated,

        [Description("Test.App.Updated")]
        AppUpdated,

        [Description("Test.App.Deleted")]
        AppDeleted,

        [Description("Test.ConnectivityProvider.Created")]
        ConnectivityProviderCreated,

        [Description("Test.ConnectivityProvider.Updated")]
        ConnectivityProviderUpdated,

        [Description("Test.ConnectivityProvider.Deleted")]
        ConnectivityProviderDeleted,

        [Description("Test.IdentityProvider.Created")]
        IdentityProviderCreated,

        [Description("Test.IdentityProvider.Updated")]
        IdentityProviderUpdated,

        [Description("Test.IdentityProvider.Deleted")]
        IdentityProviderDeleted,

        [Description("Test.Contract.Created")]
        ContractCreated,

        [Description("Test.Contract.Updated")]
        ContractUpdated,

        [Description("Test.Contract.Deleted")]
        ContractDeleted,

        [Description("Test.Grant.Created")]
        GrantCreated,

        [Description("Test.Grant.Updated")]
        GrantUpdated,

        [Description("Test.Grant.Deleted")]
        GrantDeleted,

        [Description("Test.Group.Created")]
        GroupCreated,

        [Description("Test.Group.Updated")]
        GroupUpdated,

        [Description("Test.Group.Deleted")]
        GroupDeleted,

        [Description("Test.Operation.Created")]
        OperationCreated,

        [Description("Test.Operation.Updated")]
        OperationUpdated,

        [Description("Test.Operation.Deleted")]
        OperationDeleted,

        [Description("Test.Permission.Created")]
        PermissionCreated,

        [Description("Test.Permission.Updated")]
        PermissionUpdated,

        [Description("Test.Permission.Deleted")]
        PermissionDeleted,

        [Description("Test.Resource.Created")]
        ResourceCreated,

        [Description("Test.Resource.Updated")]
        ResourceUpdated,

        [Description("Test.Resource.Deleted")]
        ResourceDeleted,

        [Description("Test.Role.Created")]
        RoleCreated,

        [Description("Test.Role.Updated")]
        RoleUpdated,

        [Description("Test.Role.Deleted")]
        RoleDeleted,

        [Description("Test.Solution.Created")]
        SolutionCreated,

        [Description("Test.Solution.Updated")]
        SolutionUpdated,

        [Description("Test.Solution.Deleted")]
        SolutionDeleted,

        [Description("Test.Tenant.Created")]
        TenantCreated,

        [Description("Test.Tenant.Updated")]
        TenantUpdated,

        [Description("Test.Tenant.Deleted")]
        TenantDeleted,

        [Description("Test.User.Created")]
        UserCreated,

        [Description("Test.User.Updated")]
        UserUpdated,

        [Description("Test.User.Deleted")]
        UserDeleted,

        [Description("Test.Access.Granted")]
        AccessGranted,

        [Description("Test.Access.Rejected")]
        AccessRejected,

        [Description("Test.Template.Created")]
        TemplateCreated,

        [Description("Test.Template.Updated")]
        TemplateUpdated,

        [Description("Test.Template.Deleted")]
        TemplateDeleted,

        [Description("Test.ServiceTier.Created")]
        ServiceTierCreated,

        [Description("Test.ServiceTier.Updated")]
        ServiceTierUpdated,

        [Description("Test.ServiceTier.Deleted")]
        ServiceTierDeleted,

        [Description("Test.Instance.Created")]
        InstanceCreated,

        [Description("Test.Instance.Updated")]
        InstanceUpdated,

        [Description("Test.Instance.Deleted")]
        InstanceDeleted,

        [Description("Test.Authentication.Success")]
        AuthenticationSuccess,

        [Description("Test.Authentication.Failed")]
        AuthenticationFailed,

        [Description("Test.Key.Generated")]
        KeyGenerated
    }
}