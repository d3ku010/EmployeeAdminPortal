# ASP.NET-Web-API

 Contains Simple Web Api built using asp dot net core web api

# Items API Documentation


---

## Endpoints

### 1. Get All Employees

**Description:** Retrieves a list of all items.
**Endpoint:** `GET /api/Employees`
**Response:**

```json
[
  {
  "id": "d0ed809e-475d-46b6-96bd-5d3d0ef97389",
  "name": "Ameen",
  "email": "am@email.com",
  "phone": "11254684",
  "salary": 50412
},
  {
  "id": "352dd499-0495-4e62-aa7b-08dd39febfbb",
  "name": "John Doe",
  "email": "jd@email.com",
  "phone": "2255",
  "salary": 49999.99
}
]
```

---

### 2. Create a New Employee

**Description:** Creates a new item.
**Endpoint:** `POST /api/Employees`
**Request Body:**

```json
{
  "name": "string",
  "email": "string",
  "phone": "string",
  "salary": 0
}
```
**Response:**

- **201 Created**

```json
{
  "id": "9fb1411a-1dc5-4d8b-1fa5-08dd3c3dd1c3",
  "name": "ABCD",
  "email": "pqrs@email.com",
  "phone": "4684184",
  "salary": 44846
}

```

### 3. Get Employee by ID

**Description:** Retrieves a specific Employee detail by ID.**Endpoint:** `GET /api/Employee/{id}`**Path Parameter:**

- **id** *(GUID)*: The unique identifier of the item.

**Response:**

- **200 OK**

```json
{
  "id": "d0ed809e-475d-46b6-96bd-5d3d0ef97389",
  "name": "Ameen",
  "email": "am@email.com",
  "phone": "11254684",
  "salary": 50412
}
```

- **404 Not Found**

```json
{
  "error": "Item not found"
}
```

---

### 4. Update an Existing Employee

**Description:** Updates the details of an existing Employee.**Endpoint:** `PUT /api/Employee/{id}`**Path Parameter:**

- **id** *(GUID)*: The unique identifier of the item.

**Request Body:**

```json
{
  "name": "LMN",
  "email": "string",
  "phone": "string",
  "salary": 0
}
```

**Response:**

- **200 OK**

```json
{
  "id": "9fb1411a-1dc5-4d8b-1fa5-08dd3c3dd1c3",
  "name": "LMN",
  "email": "string",
  "phone": "string",
  "salary": 0
}
```

---

### 5. Delete an Employee

**Description:** Deletes an item by its ID.**Endpoint:** `DELETE /api/Employee/{id}`**Path Parameter:**

- **id** *(GUID)*: The unique identifier of the item.

**Response:**

- **204 No Content**
- **404 Not Found**

```json
{
  "error": "Item not found"
}
```

---

## Notes

- Use tools like Postman, cURL, or Swagger for testing the API.
