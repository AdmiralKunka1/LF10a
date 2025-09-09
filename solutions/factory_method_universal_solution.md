Universal Step-by-Step Solution for Factory Method
1. Define a Common Interface or Base Class for the Product
Decide what unites all your objects (e.g., Animal, Vehicle, Message, Form).

Describe a common method (e.g., speak(), move(), send(), render()).

Example:

interface Animal {
    speak()
}
2. Implement Concrete Product Classes
For each type of object, create a separate class that implements the common interface.

In each class, implement its own version of the common method.

Example:

class Dog implements Animal {
    speak() → "Woof!"
}

class Cat implements Animal {
    speak() → "Meow!"
}
3. Create an Abstract Factory or Factory Interface
Define a factory with a method for creating objects (e.g., createAnimal(), createVehicle(), createMessage()).

Example:

interface AnimalFactory {
    createAnimal()
}
4. Implement Concrete Factories for Each Product Type
For each type, create a separate factory that implements the creation method for the required object.

Example:

class DogFactory implements AnimalFactory {
    createAnimal() → Dog
}

class CatFactory implements AnimalFactory {
    createAnimal() → Cat
}
5. Use the Factory to Create Objects
In your main program, create the needed factory and call its creation method.

Use the created object via the common interface.

Example:

factory = DogFactory()
animal = factory.createAnimal()
animal.speak() // "Woof!"
6. (For Tasks with Parameters) Pass Parameters to the Factory
Modify the factory method to accept parameters (e.g., color, size, speed).

Example:

class CarFactory {
    createCar(color, horsepower) → Car
}
7. (For Extensible Factories) Use Registration or Type Passing
Implement a mechanism that allows adding new object types without changing the factory code (e.g., via a dictionary or map).

Example:

factory.register("Dog", Dog)
factory.register("Cat", Cat)
animal = factory.create("Dog")
8. (For Creative/Team Tasks) Allow Adding New Types
Describe how to add a new class and register it in the factory.

9. (For UI or Game Tasks) Use a Common Method for Display or Action
For example, all forms have a render() method, all characters have attack(), etc.

Example Template (Pseudocode)
// 1. Interface
interface Product {
    action()
}

// 2. Concrete Products
class ProductA implements Product {
    action() → "A"
}
class ProductB implements Product {
    action() → "B"
}

// 3. Factory Interface
interface Factory {
    createProduct()
}

// 4. Concrete Factories
class FactoryA implements Factory {
    createProduct() → ProductA
}
class FactoryB implements Factory {
    createProduct() → ProductB
}

// 5. Usage
factory = FactoryA()
product = factory.createProduct()
product.action() // "A"