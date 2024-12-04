document.getElementById("megjelenitoGomb").addEventListener("click", () => {
    let tbody = document.getElementById("tb_konyvek");

    if (tbody.innerHTML !== "") {
        // If content exists, clear it to "hide" the table
        tbody.innerHTML = "";
    } else {
        // Otherwise, fetch and populate the table
        fetch("api/book")
            .then(v => v.json())
            .then(o => {
                console.log("GET:",o);

                tbody.innerHTML = ""; // Clear any existing content before populating

                for (let i = 0; i < o.length; i++) {
                    let sor = document.createElement("tr");
                    sor.innerHTML = `
                        <td>${o[i].id}</td>
                        <td>${o[i].title}</td>
                        <td>${o[i].author}</td>
                        <td>${o[i].year}</td>
                        <td>${o[i].genre}</td>
                        <td>${o[i].isAvailable}</td>
                    `;
                    tbody.appendChild(sor);
                }
            })
            .catch(error => console.error("Error fetching books:", error));
    }
});


document.getElementById("ujkonyvrogzito").addEventListener("click", () => {

    var bookData = {
        "title": document.getElementById("cim").value,
        "author": document.getElementById("szerzo").value,
        "year": document.getElementById("ev").value,
        "genre": document.getElementById("mufaj").value,
        "isAvailable": document.getElementById("elerheto").checked == "Ok"
    }

    fetch("api/book", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(bookData)
    }).then(v => {    
        if (v.ok) {
            alert("siker")
            location.reload();
        }
        else {
            aler("hiba")
        }
    })

    

});
