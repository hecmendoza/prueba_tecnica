using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    [OperationContract]
    DataSet Get_User(int id);

    [OperationContract]
	DataSet Get_Users();

    [OperationContract]
    void Insert_User(User user);

    [OperationContract]
    void Delete_User(int id);

    [OperationContract]
    void Update_User(User user);

    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class User
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
	public string Name { get; set; }

    [DataMember]
    public DateTime Birthdate { get; set; }

    [DataMember]
    public string Sex { get; set; }
}
