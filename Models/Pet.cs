using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;
public enum PetBreed
{
   Shepherd, Poodle, Beagle, Bulldog, Terrier, Boxer, Labrador, Retriever,
}
public enum PetColor
{
   White, Black, Golden, Tricolor, Spotted
}
public class Pet
{
   public int Id { get; set; }

   [Required]
   public string Name { get; set; }

   [Required]
   [JsonConverter(typeof(JsonStringEnumConverter))]
   public PetBreed Breed { get; set; }

   [Required]
   [JsonConverter(typeof(JsonStringEnumConverter))]
   public PetColor Color { get; set; }

   public DateTime? CheckedInAt { get; set; }

   [Required]
   // [JsonConverter(typeof(JsonStringEnumConverter))]
   public int PetOwnerid { get; set; }

}